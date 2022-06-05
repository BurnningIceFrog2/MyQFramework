using System;
namespace com.QFramework
{
    public interface IArchitectureComponentInjector:IDisposable
    {
        void PrepairInjectionData(Type baseType);
        void Inject(IArchitecture architecture);
    }
}
