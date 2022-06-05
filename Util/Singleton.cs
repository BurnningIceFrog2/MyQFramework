using System;
using System.Reflection;

namespace com.QFramework 
{
    public class Singleton<T> where T:Singleton<T> 
    {
        private static T _instance;
        public static T Instance 
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = Init();
                }
                return _instance;
            } 
        }
        private static T Init()
        {
            Type type = typeof(T);
            ConstructorInfo[] ctorArr=type.GetConstructors(BindingFlags.Instance|BindingFlags.NonPublic);
            if (ctorArr.Length==0) 
            {
                throw new Exception("Non Public Contstrucor Not Found In "+type.FullName);
            }
            ConstructorInfo ctor=Array.Find(ctorArr,c=> c.GetParameters().Length==0);
            if (ctor == null) 
            {
                throw new Exception("Non Public Contstrucor Not Found In " + type.FullName);
            }
            _instance=ctor.Invoke(null) as T;
            return _instance;
        }
    }
}
