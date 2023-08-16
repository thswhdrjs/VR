using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 석겸, 20201019
/// 인게임에서 사용할 게임오브젝트를 관리하는 클래스 (UI 제외)
/// </summary>
namespace Ispark.keitdesign
{
    public class ObjectManager : Singleton<ObjectManager>
    {
        /// <summary>
        /// Ingame 에서 사용되는 오브젝트를 모아놓은 Dictionary. 
        /// </summary>
        [SerializeField] ObjectDictionary ingameObjectDic = new ObjectDictionary();

        /// <summary>
        /// 게임 오브젝트를 가져옵니다.
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
        /// 게임오브젝트를 추가합니다.
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
