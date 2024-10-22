using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace BricksBucket.Postman
{
    [Serializable]
    public class Header : StringObjectWrapper<List<HeaderObject>>
    {
        public static implicit operator Header(List<HeaderObject> obj)
        {
            return new Header { Object = obj };
        }

        public static implicit operator Header(string s)
        {
            return new Header { String = s };
        }
    }

    /// <summary>
    ///     A representation for a list of headers
    ///     Represents a single HTTP Header
    /// </summary>
    [Serializable]
    public class HeaderObject
    {
        [SerializeField] private string m_key;

        [SerializeField] private string m_value;

        [SerializeField] private Description m_description;

        [SerializeField] private BoolWrapper m_disabled;


        /// <summary>
        ///     This holds the LHS of the HTTP Header, e.g ``Content-Type`` or
        ///     ``X-Custom-Header``
        /// </summary>
        [JsonProperty("key", Required = Required.Always)]
        public string Key
        {
            get => m_key;
            set => m_key = value;
        }

        /// <summary>
        ///     The value (or the RHS) of the Header is stored in this field.
        /// </summary>
        [JsonProperty("value", Required = Required.Always)]
        public string Value
        {
            get => m_value;
            set => m_value = value;
        }

        [JsonProperty("description")]
        public Description Description
        {
            get => m_description;
            set => m_description = value;
        }

        /// <summary>
        ///     If set to true, the current header will not be sent with requests.
        /// </summary>
        [JsonProperty("disabled", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public BoolWrapper Disabled
        {
            get => m_disabled;
            set => m_disabled = value;
        }
    }
}