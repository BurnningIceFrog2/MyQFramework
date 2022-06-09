using UnityEngine;
namespace LGUVirtualOffice.Framework
{
    public static class IUnSubscribeExtension
    {
        public static void UnSubScribeWhenGameObjectDestroyed(this  IUnSubscribe unSubscribe,GameObject gameObject) 
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
