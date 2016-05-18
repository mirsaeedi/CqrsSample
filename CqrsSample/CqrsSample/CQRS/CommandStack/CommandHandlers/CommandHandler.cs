using System;
using System.Threading.Tasks;
using CqrsSample.CQRS.CommandStack.Commands;
using CqrsSample.Data.DataContext;
using CqrsSample.Data.Models;

namespace CqrsSample.CQRS.CommandStack.CommandHandlers
{
    public abstract class CommandHandler<TCommand, TCommandResult> : ICommandHandler<TCommand, TCommandResult>
        where TCommand : CqrsCommand
        where TCommandResult : CqrsCommandResult
    {
        private IDataContext _innerDataContext { get;  set; } // این قابل دور زدن هست و مخقی نیست
        protected ISetDataContext SetDataContext { get; private set; }
        protected bool ParentOfChain { get; set; }
        internal Entity CommandEntity { get; set; }

        internal CommandHandler(IDataContext innerDataContext, bool parentOfChain = true)
        {
            _innerDataContext = innerDataContext;
            ParentOfChain = parentOfChain;

            SetDataContext = new SetDataContext(innerDataContext);
        }

        public async Task<TCommandResult> Execute(TCommand command, int userId, string ip)
        {
            try
            {
                if (ActivityAuthorizationIsConfirmed(userId))
                {
                    SaveCommand(command);

                    GetLock();
                    
                    var result = await Execute(command, userId);
                    SaveCommandResult(result);

                    if (result.MetaData.WasSuccesfull)
                    {
                        if (ParentOfChain)
                        {
                            await _innerDataContext.SaveChangesAsync();
                            OnSucess(command, result);
                        }

                    }
                    else
                        OnFail(null, command, result);

                    return result;
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

        internal virtual void GetLock()
        {

        }

        internal virtual void ReleaseLock()
        {

        }

        private TCommandResult HandleFailed(Exception exception, TCommand command)
        {
            return null;
        }

        protected virtual bool ActivityAuthorizationIsConfirmed(int userId)
        {
            return true;
        }

        public virtual async Task<TCommandResult> Execute(TCommand command, int userId)
        {
            var commandResult = PreExecutionValidation(command, userId);

            if (commandResult.MetaData.WasSuccesfull)
            {
                await Handle(command, userId);
                PostExecutionValidate(command, commandResult);
            }

            return commandResult;
        }

        internal virtual async Task Handle(TCommand command, int userId) { }

        protected virtual void SaveCommand(TCommand command) { }

        protected virtual void SaveCommandResult(TCommandResult commandResult) { }

        protected virtual void OnSucess(TCommand command, TCommandResult commandResult) { }

        protected virtual void OnFail(Exception exception, TCommand command, TCommandResult commandResult) { }

        protected virtual TCommandResult CreateFailedResult(Exception exception, TCommand command)
        {
            return new CqrsCommandResult(-100, exception.ToString(),command) as TCommandResult;
        }

        protected virtual void PostExecutionValidate(TCommand command, TCommandResult commandResult) { }

        internal abstract TCommandResult PreExecutionValidation(TCommand command, int userId);

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