using System;
using System.Threading.Tasks;
using Kaftar.Core.CQRS.CommandStack.Commands;
using Kaftar.Core.Data.DataContext;
using Kaftar.Core.Data.Models;

namespace Kaftar.Core.CQRS.CommandStack.CommandHandlers
{
    public abstract class CommandHandler<TCommand, TCommandResult> : ICommandHandler<TCommand, TCommandResult>
        where TCommand : CqrsCommand
        where TCommandResult : CqrsCommandResult
    {
        internal IDataContext InnerDataContext { get;  set; }
        protected ISetDataContext SetDataContext { get; private set; }
        protected bool ParentOfChain { get; set; }
        internal Entity CommandEntity { get; set; }

        public CommandHandler()
        {
            ParentOfChain = true;
        }

        public async Task<TCommandResult> Execute(TCommand command)
        {
            try
            {
                SetDataContext = new SetDataContext(InnerDataContext);

                if (ActivityAuthorizationIsConfirmed(command))
                {
                    SaveCommand(command);

                    GetLock();

                    var commandResult = PreExecutionValidation(command);

                    if (commandResult.MetaData.WasSuccesfull)
                    {
                        await Handle(command);
                        PostExecutionValidate(command, commandResult);
                    }

                    SaveCommandResult(commandResult);

                    if (commandResult.MetaData.WasSuccesfull)
                    {
                        if (ParentOfChain)
                        {
                            await InnerDataContext.SaveChangesAsync();
                            OnSucess(command, commandResult);
                        }

                    }
                    else
                        OnFail(null, command, commandResult);

                    return commandResult;
                }
                else
                {
                    throw new Exception("Not Authorized");
                }
            }
            catch (Exception exception)
            {
                return HandleFailed(exception, command);
            }
            finally
            {
                ReleaseLock();
            }
        }

        protected virtual void GetLock()
        {

        }

        protected virtual void ReleaseLock()
        {

        }

        private TCommandResult HandleFailed(Exception exception, TCommand command)
        {
            return null;
        }

        protected virtual bool ActivityAuthorizationIsConfirmed(TCommand command)
        {
            return true;
        }

        protected abstract Task Handle(TCommand command);

        protected virtual void SaveCommand(TCommand command) { }

        protected virtual void SaveCommandResult(TCommandResult commandResult) { }

        protected virtual void OnSucess(TCommand command, TCommandResult commandResult) { }

        protected virtual void OnFail(Exception exception, TCommand command, TCommandResult commandResult) { }

        protected virtual TCommandResult CreateFailedResult(Exception exception, TCommand command)
        {
            return new CqrsCommandResult(-100, exception.ToString(),command) as TCommandResult;
        }

        protected virtual void PostExecutionValidate(TCommand command, TCommandResult commandResult) { }

        protected abstract TCommandResult PreExecutionValidation(TCommand command);

        protected CqrsCommandResult OkResult(TCommand command)
        {
            return new CqrsCommandResult(0,null, command);
        }

        protected CqrsCommandResult FailedExceptionResult(TCommand command)
        {
            return new CqrsCommandResult(-1, "Unhandled Exception", command);
        }

    }
}