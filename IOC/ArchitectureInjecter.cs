using System;

namespace LGUVirtualOffice.Framework
{
    public class ArchitectureInjecter:IInjector
    {
        private IArchitectureComponentInjector controllerInjector;
        private IArchitectureComponentInjector serviceInjector;
        private IArchitectureComponentInjector modelInjector;
        private IArchitectureComponentInjector utilityInjector;
        public ArchitectureInjecter() 
        {
            controllerInjector = new ControllerInjector();
            serviceInjector = new ServiceInjector();
            modelInjector = new ModelInjector();
            utilityInjector = new UtilityInjector();
        }
        public void PrepairInjectionData(Type processtype)
        {
            PrepairInjectionDataImpl(processtype);
        }
        private void PrepairInjectionDataImpl(Type baseType) 
        {
            if (!TypeChecker.Instance.IsCanInject(baseType)) 
            {
                return;
            }
            if (TypeChecker.Instance.IsController(baseType))
            {
                PrepairControllerInjectionData(baseType);
            }
            if (TypeChecker.Instance.IsService(baseType))
            {
                PrepairServiceInjectionData(baseType);
            }
            if (TypeChecker.Instance.IsModel(baseType))
            {
                PrepairModelInjectionData(baseType);
            }
            if (TypeChecker.Instance.IsUtility(baseType))
            {
                PrepairUtilityInjectionData(baseType);
            }
        }
        public void Inject(IArchitecture architecture)
        {
            InjectImpl(architecture);
        }

        public void Dispose() 
        {
            controllerInjector.Dispose();
            serviceInjector.Dispose();
            modelInjector.Dispose();
            utilityInjector.Dispose();
            controllerInjector = null;
            serviceInjector = null;
            modelInjector = null;
            utilityInjector = null;
        }
        private void InjectImpl(IArchitecture architecture) 
        {
            controllerInjector.Inject(architecture);
            serviceInjector.Inject(architecture);
            modelInjector.Inject(architecture);
            utilityInjector.Inject(architecture);
        }
        
        private void PrepairControllerInjectionData(Type baseType)
        {
            controllerInjector.PrepairInjectionData(baseType);
        }
       
        private void PrepairServiceInjectionData(Type baseType)
        {
            serviceInjector.PrepairInjectionData(baseType);
        }
        private void PrepairModelInjectionData(Type baseType)
        {
            modelInjector.PrepairInjectionData(baseType);
        }

        private void PrepairUtilityInjectionData(Type baseType)
        {
            utilityInjector.PrepairInjectionData(baseType);
        }
    }
}
