using System;
namespace com.QFramework
{
    public interface IQueryHandler
    {
        R DoQuery<Q,R>() where Q:IQuery<R>,new();
        R DoQuery<R>(IQuery<R> query);
        IQueryResult<R> DoQueryAsync<R>(IQuery<R> query);
        IQueryResult<R> DoQueryAsync<Q,R>() where Q:IQuery<R>,new();
    }
}
