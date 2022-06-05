using System;
namespace com.QFramework
{
    public interface IInjector:IDisposable
    {
        public void PrepairInjectionData(Type processType);
        public void Inject(IArchitecture architectureInstance);
    }
}
