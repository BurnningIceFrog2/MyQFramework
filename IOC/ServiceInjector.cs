using System;
namespace com.QFramework
{
    public class ServiceInjector : AbstractArchitectureComponentInjector
    {
        public ServiceInjector():base(typeof(IService)){}
        protected override object GetInjectObject(Type baseType)
        {
            return architectureInstance.GetService(baseType);
        }
    }
}
