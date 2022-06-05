using System;
namespace com.QFramework
{

    public class ModelInjector : AbstractArchitectureComponentInjector
    {
        public ModelInjector() : base(typeof(IModel)) { }
        protected override object GetInjectObject(Type baseType)
        {
            return architectureInstance.GetModel(baseType);
        }
    }
}
