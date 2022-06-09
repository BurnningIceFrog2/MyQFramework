using System;
using System.Collections.Generic;
namespace LGUVirtualOffice.Framework
{
    public abstract class AbstractArchitecture<T>:IArchitecture where T:AbstractArchitecture<T>,new() 
    {
        private static IArchitecture architectureInstance;
        private List<IModel> modelList;
        private List<IService> serviceList;
        private IOCContainer serviceContainer=new IOCContainer();
        private IOCContainer modelContainer = new IOCContainer();
        private IOCContainer utilityContainer = new IOCContainer();
        private ITypeEventSystem eventSystem=new DefaultTypeEventSystem();
        private ICommandHandler commandHandle=new DefaultCommandHandler();
        private IQueryHandler queryHandler = new DefaultQueryHandler();

        void IArchitecture.SetArchitectureInstance(IArchitecture instance) 
        {
            architectureInstance = instance;
            ICanGetModelExtension.SetArchitecture(architectureInstance);
            ICanGetServiceExtension.SetArchitecture(architectureInstance);
            ICanGetUtilityExtension.SetArchitecture(architectureInstance);
            IArchitectureModuleExtension.SetArchitecture(architectureInstance);
            ICanSendCommandExtension.SetCommandHandler(commandHandle);
            ICanTriggerEventExtension.SetEventSystem(eventSystem);
            ICanSubscribeEventExtension.SetEventSystem(eventSystem);
            IChainEventUnSubcribeExtension.SetEventSystem(eventSystem);
            ICanSendQueryExtension.SetQueryHandler(queryHandler);
        }
        void IArchitecture.InitArchitecture()
        {
            modelList = new List<IModel>();
            serviceList = new List<IService>();
            OnInit();
            InitModels();
            InitServices();
        }

        private void InitModels() 
        {
            foreach (var model in modelList)
            {
                model.OnInit();
            }
            modelList.Clear();
            modelList = null;
        }

        private void InitServices() 
        {
            foreach (var service in serviceList)
            {
                service.OnInit();
            }
            serviceList.Clear();
            serviceList = null;
        }
        protected abstract void OnInit();
        protected virtual void SetTypeEventSystem(ITypeEventSystem typeEventSystem) 
        {
            eventSystem = typeEventSystem;
        }

        public K GetService<K>() where K : IService
        {
            return serviceContainer.Get<K>();
        }
        public K GetModel<K>() where K:IModel
        {
            return modelContainer.Get<K>();
        }
        public K GetUtility<K>() where K : IUtility
        {
            return utilityContainer.Get<K>();
        }
        public object GetService(Type type) 
        {
            return serviceContainer.Get(type);
        }
        public object GetModel(Type type) 
        {
            return modelContainer.Get(type);
        }
        public object GetUtility(Type type) 
        {
            return utilityContainer.Get(type);
        }
        public void RegisterService<K>() where K : IService, new()
        {
            RegisterService(new K());
        }
        public void RegisterModel<K>() where K :  IModel, new()
        {
            RegisterModel(new K());
        }

        public void RegisterUtility<K>() where K : IUtility, new()
        {
            RegisterUtility(new K());
        }

        public void RegisterModel<K>(K modelInstance) where K : IModel
        {
            modelContainer.Register(modelInstance);
            modelList.Add(modelInstance);
        }

        public void RegisterService<K>(K serviceInstance) where K : IService
        {
            serviceContainer.Register(serviceInstance);
            serviceList.Add(serviceInstance);
        }

        public void RegisterUtility<K>(K utilityInstance) where K : IUtility
        {
            utilityContainer.Register(utilityInstance);
        }
    }
}
