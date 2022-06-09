using System;
namespace LGUVirtualOffice.Framework
{
    public interface IInjector:IDisposable
    {
        public void PrepairInjectionData(Type processType);
        public void Inject(IArchitecture architectureInstance);
    }
}
