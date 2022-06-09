using UnityEngine;

namespace LGUVirtualOffice.Framework
{
    public class SingletonMonobehaviour<T> : MonoBehaviour where T:SingletonMonobehaviour<T>
    {
        private static T _instance;

        public static T Instance 
        {
            get => _instance;
        }

        public virtual void OnStart() { }
        private void Start()
        {
            if (_instance == null)
            {
                _instance = this.GetComponent<T>();
                _instance.OnStart();
                DontDestroyOnLoad(_instance);
            }
            else 
            {
                Destroy(gameObject);
            }
        }
    }
}
