using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace BricksBucket.Postman
{
    [Serializable]
    public abstract class SerializableDictionary<TKey, TValue> :
        Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [FormerlySerializedAs("m_keyData")] [SerializeField] [HideInInspector]
        private List<TKey> keyData = new List<TKey>();

        [FormerlySerializedAs("m_valueData")] [SerializeField] [HideInInspector]
        private List<TValue> valueData = new List<TValue>();

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            Clear();
            for (var i = 0; i < keyData.Count && i < valueData.Count; i++)
                this[keyData[i]] = valueData[i];
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            keyData.Clear();
            valueData.Clear();

            foreach (var item in this)
            {
                keyData.Add(item.Key);
                valueData.Add(item.Value);
            }
        }
    }
}