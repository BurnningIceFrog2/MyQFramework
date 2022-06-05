using System;
using System.Reflection;

namespace com.QFramework
{
    public class TypeChecker:HungrySingleton<TypeChecker>
    {
        private Type controllerType;
        private Type serviceType;
        private Type modelType;
        private Type utilityType;
        private Type canInjectBaseType;
        private TypeChecker() 
        {
            controllerType = typeof(IController);
            serviceType = typeof(IService);
            modelType = typeof(IModel);
            utilityType = typeof(IUtility);
            canInjectBaseType = typeof(ICanInject);
        }

        public bool IsCanInject(Type type)
        {
            return canInjectBaseType.IsAssignableFrom(type);
        }
        public bool IsController(Type type)
        {
            return controllerType.IsAssignableFrom(type);
        }
        public bool IsService(Type type)
        {
            return serviceType.IsAssignableFrom(type);
        }
        public bool IsModel(Type type)
        {
            return modelType.IsAssignableFrom(type);
        }
        public bool IsUtility(Type type)
        {
            return utilityType.IsAssignableFrom(type);
        }
    }
}
