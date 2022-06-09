using System.Collections.Generic;
using System;

namespace LGUVirtualOffice.Framework
{
    public class IOCContainer
    {
        private Dictionary<Type, object> container = new Dictionary<Type, object>();

        public void Register<T>() where T:new()
        {
            Register(new T());
        }
        public void Register<T>(T instance) 
        {
            Type t = typeof(T);
            if (container.ContainsKey(t))
            {
                container[t] = instance;
            }
            else 
            {
                container.Add(t,instance);
            }
        }
        public object Get(Type type) 
        {
            if (container.TryGetValue(type,out object instance)) 
            {
                return instance;
            }
            return default;
        }
        public T Get<T>()
        {
            Type t = typeof(T);
            if (container.TryGetValue(t, out object instance))
            {
                return (T)instance;
            }
            else 
            {
                throw new Exception("Can Not Find Instance of type "+t.FullName+",Please Call Register At First!");
            }
        }
    }
}
