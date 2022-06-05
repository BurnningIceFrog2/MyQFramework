using System;
namespace com.QFramework
{

    public class UtilityInjector : AbstractArchitectureComponentInjector
    {
        public UtilityInjector():base(typeof(IUtility)){ }
        protected override object GetInjectInstance(Type injectType)
        {
            return architectureInstance;
        }
        protected override object GetInjectObject(Type baseType)
        {
            return architectureInstance.GetUtility(baseType);
        }
    }
}
