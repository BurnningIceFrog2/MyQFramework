using System.Threading.Tasks;

namespace LGUVirtualOffice.Framework
{
    public class DefaultQueryHandler : IQueryHandler
    {

        public R DoQuery<Q, R>() where Q : IQuery<R>, new()
        {
            return DoQuery(new Q());
        }

        public R DoQuery<R>(IQuery<R> query)
        {
            return query.DoQuery();
        }

        
        public IQueryResult<R> DoQueryAsync<R>(IQuery<R> query)
        {
            DefaultQueryResult<R> queryResult = new DefaultQueryResult<R>();
            var queryTask = Task.Run(() => {
                return query.DoQuery();
            });
            var awaiter = queryTask.GetAwaiter();
            awaiter.OnCompleted(() => {
                if (queryTask.IsFaulted | queryTask.IsCanceled)
                {
                    queryResult.TriggerFailed();
                }
                else
                {
                    queryResult.TriggerSuccess(awaiter.GetResult());
                }
            });
            return queryResult;
        }
        public IQueryResult<R> DoQueryAsync<Q, R>() where Q : IQuery<R>, new()
        {
            return DoQueryAsync(new Q());
        }
    }
}
