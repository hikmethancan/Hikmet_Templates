using System;
using UnityEngine;

namespace Deneme.Scripts
{
    public abstract class SingletonObjects<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; set; }

        protected virtual void Awake()
        {
            SingletonObject();
        }

        protected void SingletonObject()
        {
            if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
        
    }
}
