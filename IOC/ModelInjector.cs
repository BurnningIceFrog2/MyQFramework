using System;
namespace LGUVirtualOffice.Framework
{

    public class ModelInjector : AbstractArchitectureComponentInjector
    {
        private Type modelType;
        public ModelInjector() : base(typeof(IModel)) {
            modelType = typeof(IModel);
        }
        protected override object GetInjectObject(Type baseType)
        {
            object instance = architectureInstance.GetModel(baseType);
            if (instance == null)
            {
                var interfaces = baseType.GetInterfaces();
                foreach (var type in interfaces)
                {
                    if (modelType.IsAssignableFrom(type)&&!modelType.Equals(type))
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
