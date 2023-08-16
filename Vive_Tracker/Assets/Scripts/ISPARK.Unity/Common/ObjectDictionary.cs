using System;
using UnityEngine;

namespace Ispark.keitdesign
{
    /// <summary>
    /// 직렬화 Dictionary 구현 클래스
    /// </summary>
    [Serializable]
    public class ObjectDictionary : SerializableDictionary<string, GameObject> { }

}