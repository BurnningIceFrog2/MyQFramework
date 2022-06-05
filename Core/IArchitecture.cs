using System;
using System.Collections.Generic;
namespace com.QFramework 
{
    public interface IArchitecture
    {
        void SetArchitectureInstance(IArchitecture instance);
        void InitArchitecture();
        //object GetObject(Type type);
        T GetService<T>() where T : IService;
        T GetModel<T>() where T : IModel;
        T GetUtility<T>() where T : IUtility;
        object GetService(Type type);
        object GetModel(Type type);
        object GetUtility(Type type);
        void RegisterService<T>() where T : IService,new();
        void RegisterModel<T>() where T : IModel,new();
        void RegisterUtility<T>() where T : IUtility,new();

        void RegisterModel<T>(T modelInstance) where T : IModel;
        void RegisterService<T>(T serviceInstance) where T : IService;
        void RegisterUtility<T>(T utilityInstance) where T : IUtility;

        /*void SendCommand<T>() where T : ICommand,new();
        void SendCommand<T>(T command) where T : ICommand;

        R SendQuery<Q, R>() where Q : IQuery, new();
        R SendQuery<Q, R>(Q queryInstance) where Q : IQuery;
        void SendQueryAsync<Q,R>(Action<R> onQueryCompleted) where Q : IQueryAsync, new();
        void SendQueryAsync<Q, R>(Q queryInstance,Action<R> onQueryCompleted) where Q : IQueryAsync;

        void TriggerEvent<T>() where T : IEvent, new();
        void TriggerEvent<T>(T e) where T : IEvent;

        IUnSubscribe SubscribeEvent<T>(Action<T> onEvent) where T : IEvent;
        void UnSubscribe<T>(Action<T> onEvent) where T : IEvent;*/
    }
}
