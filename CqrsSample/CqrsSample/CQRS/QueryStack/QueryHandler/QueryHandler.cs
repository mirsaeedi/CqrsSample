using System;
using System.Threading.Tasks;
using CqrsSample.Data.DataContext;
using CqrsSample.QueryStack;
using CqrsSample.QueryStack.Queries;
using CqrsSample.QueryStack.QueryHandler;

namespace CqrsSample.CQRS.QueryStack.QueryHandler
{
    public abstract class QueryHandler<TQuery, TQueryValueResult> : IQueryHandler<TQuery, TQueryValueResult>
                    where TQuery : CqrsQuery where TQueryValueResult : class
    {
        protected IReadOnlyDataContext DataContext { get; private set; }

        public QueryHandler(IReadOnlyDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<CqrsQueryResult<TQueryValueResult>> Execute(TQuery query, int userId, string ip)
        {
            try
            {
                if (ActivityAuthorizationIsConfirmed(userId))
                {
                    SaveQuery(query);
                    var result = await Execute(query, userId);
                    SaveQueryResult(result);

                    if (result.MetaData.WasSuccesfull)
                        OnSucess(query, result);
                    else
                        OnFail(null, query, result);

                    return result;
                }
                else
                {
                    throw new Exception("Not Authorized");
                }
            }
            catch (Exception exception)
            {
                return HandleFailed(exception, query);
            }
            finally
            {
                
            }
        }

        private CqrsQueryResult<TQueryValueResult> HandleFailed(Exception exception, TQuery query)
        {
            return null;
        }

        protected virtual bool ActivityAuthorizationIsConfirmed(int userId)
        {
            return true;
        }

        public async Task<CqrsQueryResult<TQueryValueResult>> Execute(TQuery query, int userId)
        {
            var queryResult = PreExecutionValidation(query);

            if (queryResult.MetaData.WasSuccesfull)
            {
                var value = await GetResult(query, userId);
                queryResult.Value = value;
                PostExecutionValidation(query, value, queryResult);
            }

            return queryResult;
        }

        internal virtual void PostExecutionValidation(TQuery query, TQueryValueResult value, CqrsQueryResult<TQueryValueResult> queryResult)
        {

        }

        internal virtual async Task<TQueryValueResult> GetResult(TQuery query, int userId) { return default(TQueryValueResult); }

        internal virtual CqrsQueryResult<TQueryValueResult> PreExecutionValidation(TQuery query)
        {
            return OkResult(query);
        }

        protected virtual void SaveQuery(TQuery query) { }

        protected virtual void SaveQueryResult(CqrsQueryResult<TQueryValueResult> queryResult) { }

        protected virtual void OnSucess(TQuery query, CqrsQueryResult<TQueryValueResult> queryResult) { }

        protected virtual void OnFail(Exception exception, TQuery query, CqrsQueryResult<TQueryValueResult> queryResult) { }

        protected virtual CqrsQueryResult<TQueryValueResult> CreateFailedResult(Exception exception, TQuery query)
        {
            var result = new CqrsQueryResult<TQueryValueResult>(-100,  exception.ToString(),query,null);
            return result;
        }

        protected CqrsQueryResult<TQueryValueResult> OkResult(TQuery query)
        {
            return new CqrsQueryResult<TQueryValueResult>(0, query, null);
        }

        protected CqrsQueryResult<TQueryValueResult> FailedExceptionResult(TQuery query)
        {
            return new CqrsQueryResult<TQueryValueResult>(-1, "Unhandled Exception", query,null);
        }

    }
}