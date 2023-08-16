using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����, 20201019
/// �ΰ��ӿ��� ����� ���ӿ�����Ʈ�� �����ϴ� Ŭ���� (UI ����)
/// </summary>
namespace Ispark.keitdesign
{
    public class ObjectManager : Singleton<ObjectManager>
    {
        /// <summary>
        /// Ingame ���� ���Ǵ� ������Ʈ�� ��Ƴ��� Dictionary. 
        /// </summary>
        [SerializeField] ObjectDictionary ingameObjectDic = new ObjectDictionary();

        /// <summary>
        /// ���� ������Ʈ�� �����ɴϴ�.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GameObject GetGameObject(string name)
        {
            GameObject o;
            if(ingameObjectDic.TryGetValue(name, out o))
            {
                return o;
            }

            return null;
        }

        public ObjectDictionary GetIngameDic()
        {
            return ingameObjectDic;
        }

        /// <summary>
        /// ���ӿ�����Ʈ�� �߰��մϴ�.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public string AddObject(string key, GameObject o)
        {
            if (ingameObjectDic.ContainsKey(key))
            {
                return "Fail. Duplicate key";
            }
            else
            {
                ingameObjectDic.Add(key, o);
                return "Add sucess.";
            }
        }

        public bool RemoveObject(string key)
        {
            return ingameObjectDic.Remove(key);
        }
    }
}
