using System;
using System.Reflection;
using UnityEngine;

namespace LGUVirtualOffice.Framework
{
    internal sealed class ArchitectureInitiator
    {
        private ArchitectureInitiator() { }

        private Type architectureType = typeof(IArchitecture);
        private IArchitecture architectureInstance = null;
        private IInjector mInjector;
        private bool architectureInited = false;
        //private bool
        private static ArchitectureInitiator mInstance;
        private ModuleInitiator moduleInitiator;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Initiate()
        {
            mInstance = new ArchitectureInitiator();
            mInstance.CreateInjector();
            mInstance.CreateModuleInitiator();
            Type[] typeArr = Assembly.GetExecutingAssembly().GetTypes();
            int typeLength = typeArr.Length;
            for (int i = 0; i < typeLength; i++)
            {
                Type tmpType = typeArr[i];
                if (!tmpType.IsInterface) 
                {
                    if (mInstance.IsArchitecture(tmpType))
                    {
                        mInstance.CreateArchitectureInstance(tmpType);
                    }
                    mInstance.PrepairModuleData(tmpType);
                    mInstance.PrepairInjectionData(tmpType);
                }
            }
            mInstance.InitArchitecture();
            mInstance.InitModule();
            mInstance.Inject();
            mInstance.Clear();
            
        }
        private void Clear() 
        {
            mInjector.Dispose();
            moduleInitiator.Dispose();
            mInjector = null;
            moduleInitiator = null;
            mInstance = null;
        }
        private void Inject() 
        {
            mInjector.Inject(architectureInstance);
        }
        private void InitArchitecture()
        {
            if (architectureInstance != null)
            {
                architectureInstance.SetArchitectureInstance(architectureInstance);
                architectureInstance.InitArchitecture();
            }
        }
        private void InitModule() 
        {
            moduleInitiator.InitModule();
        }
        private bool IsArchitecture(Type tmpType)
        {
            if (architectureInited) 
            {
                return false;
            }
            if (tmpType.IsAbstract)
            {
                return false;
            }
            return architectureType.IsAssignableFrom(tmpType);
        }
        private void PrepairModuleData(Type type) 
        {
            moduleInitiator.PrepairModuleData(type);
        }

        private void CreateArchitectureInstance(Type archiType)
        {
            if (architectureInstance == null)
            {
                architectureInstance = (IArchitecture)Activator.CreateInstance(archiType);
                architectureInited = true;
            }
            else
            {
                throw new Exception("More than one Architecture sub-class in the application,it should be only one!");
            }
        }
        private void PrepairInjectionData(Type type) 
        {
            mInjector.PrepairInjectionData(type);
        }
        private void CreateModuleInitiator() 
        {
            moduleInitiator=new ModuleInitiator();
        }
        private void CreateInjector() 
        {
            mInjector = new ArchitectureInjecter();
        }
    }
}
