using UnityEngine;

namespace Nirvana.Toolkit
{
    public abstract class SingletonBehaviour<T> : Behaviour where T : SingletonBehaviour<T>
    {
        public static bool Exist { get { return _instance != null; } }

        private static readonly object _lock = new object();
        private static bool _shutdown = false;
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_shutdown)
                {
                    Debug.LogWarning("[Singleton] Instance '" + typeof(T) + "' already destroyed");
                    return null;
                }

                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = FindObjectOfType<T>();
                            if (_instance == null)
                            {
                                var singletonGo = new GameObject(typeof(T).Name + " [Singleton]");
                                _instance = singletonGo.AddComponent<T>();

                                DontDestroyOnLoad(_instance);
                            }
                        }
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        protected virtual void OnDestroy()
        {
            if (_instance == null)
            {
                _shutdown = true;
            }
        }

        protected virtual void OnApplicationQuit()
        {
            if (_instance == this)
            {
                _shutdown = true;
            }
        }
    }
}