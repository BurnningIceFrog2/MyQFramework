using System;
namespace LGUVirtualOffice.Framework
{

    public class UtilityInjector : AbstractArchitectureComponentInjector
    {
        private Type utilityType;
        public UtilityInjector():base(typeof(IUtility))
        {
            utilityType = typeof(IUtility);
        }
        protected override object GetInjectObject(Type baseType)
        {
            object instance = architectureInstance.GetUtility(baseType);
            if (instance == null)
            {
                var interfaces = baseType.GetInterfaces();
                foreach (var type in interfaces)
                {
                    if (utilityType.IsAssignableFrom(type)&&!utilityType.Equals(type))
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
