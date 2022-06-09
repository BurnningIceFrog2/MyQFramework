using System;
namespace LGUVirtualOffice.Framework
{
    public class ServiceInjector : AbstractArchitectureComponentInjector
    {
        private Type serviceType;
        public ServiceInjector():base(typeof(IService)) {
            serviceType = typeof(IService);
        }
        protected override object GetInjectObject(Type baseType)
        {
            object instance= architectureInstance.GetService(baseType);
            if (instance == null) 
            {
                var interfaces = baseType.GetInterfaces();
                
                foreach (var type in interfaces)
                {
                    if (serviceType.IsAssignableFrom(type)&&!serviceType.Equals(type)) 
                    {
                        instance = architectureInstance.GetService(type);
                        if (instance != null) 
                        {
                            break;
                        }
                    }
                }
            }
            return instance;
        }
    }
}
