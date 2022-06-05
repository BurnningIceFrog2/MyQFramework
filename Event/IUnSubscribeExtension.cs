using UnityEngine;
using System;
namespace com.QFramework
{
    public static class IUnSubscribeExtension
    {
        /*private static ITypeEventSystem _eventSystem;
        public static void SetEventSystem(ITypeEventSystem eventSystem)
        {
            _eventSystem = eventSystem;
        }*/
        public static void UnSubscribeOnGameobjectDestroyed(this  IUnSubscribe unSubscribe,GameObject gameObject) 
        {
            var trigger= gameObject.GetComponent<UnSubscribeOnDestroyTrigger>();
            if (!trigger) 
            {
                trigger = gameObject.AddComponent<UnSubscribeOnDestroyTrigger>();
            }
            trigger.AddUnSubscribe(unSubscribe);
        }
    }
}
