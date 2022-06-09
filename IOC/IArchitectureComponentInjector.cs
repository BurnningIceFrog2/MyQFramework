using System;
namespace LGUVirtualOffice.Framework
{
    public interface IArchitectureComponentInjector:IDisposable
    {
        void PrepairInjectionData(Type baseType);
        void Inject(IArchitecture architecture);
    }
}
