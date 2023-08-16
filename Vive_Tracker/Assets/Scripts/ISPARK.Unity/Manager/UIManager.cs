using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 인게임에서 사용할 UI오브젝트를 관리하는 클래스 
/// </summary>
namespace Ispark.keitdesign
{
    public class UIManager : Singleton<UIManager>
    {
        /// <summary>
        /// Ingame 에서 사용되는 UI 오브젝를 모아놓은 Dictionary
        /// </summary>
        [SerializeField] UIDictionary ingameUIObjectDic = new UIDictionary();

        /// <summary>
        /// 게임 오브젝트를 가져옵니다.
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
        /// 게임오브젝트를 추가합니다.
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
