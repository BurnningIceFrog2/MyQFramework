using System;
namespace LGUVirtualOffice.Framework
{
    public interface IArchitecture
    {
        void SetArchitectureInstance(IArchitecture instance);
        void InitArchitecture();
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
    }
}
