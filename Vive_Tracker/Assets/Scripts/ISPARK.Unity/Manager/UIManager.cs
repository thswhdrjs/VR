using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ΰ��ӿ��� ����� UI������Ʈ�� �����ϴ� Ŭ���� 
/// </summary>
namespace Ispark.keitdesign
{
    public class UIManager : Singleton<UIManager>
    {
        /// <summary>
        /// Ingame ���� ���Ǵ� UI �������� ��Ƴ��� Dictionary
        /// </summary>
        [SerializeField] UIDictionary ingameUIObjectDic = new UIDictionary();

        /// <summary>
        /// ���� ������Ʈ�� �����ɴϴ�.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GameObject GetGameObject(string name)
        {
            GameObject o;
            if (ingameUIObjectDic.TryGetValue(name, out o))
            {
                return o;
            }

            return null;
        }
        public UIDictionary GetIngameDic()
        {
            return ingameUIObjectDic;
        }

        /// <summary>
        /// ���ӿ�����Ʈ�� �߰��մϴ�.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public string AddObject(string key, GameObject o)
        {
            if (ingameUIObjectDic.ContainsKey(key))
            {
                return "Fail. Duplicate key.";
            }
            else
            {
                ingameUIObjectDic.Add(key, o);
                return "Add sucess.";
            }
        }

        public bool RemoveObject(string key)
        {
            return ingameUIObjectDic.Remove(key);
        }
    }
}
