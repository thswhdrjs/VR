using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ispark.keitdesign
{
    /// <summary>
    /// Monobehavior �� �̱������� ������ִ� Generic Ŭ����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        private static T Get
        {
            get
            {
                if(instance == null)
                {
                    GameObject obj;
                    obj = GameObject.Find(typeof(T).Name);
                    if(obj == null)
                    {
                        obj = new GameObject(typeof(T).Name);
                        instance = obj.AddComponent<T>();
                    }
                    else
                    {
                        instance = obj.GetComponent<T>();
                    }
                }
                return instance;
            }
        }

        public void Awake()
        {
            //DontDestroyOnLoad(gameObject);
        }
    }
}
