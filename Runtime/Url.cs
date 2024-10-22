using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace BricksBucket.Postman
{
    [Serializable]
    public class Url : StringObjectWrapper<UrlObject>
    {
        public static implicit operator Url(UrlObject urlObject)
        {
            return new Url { Object = urlObject };
        }

        public static implicit operator Url(string s)
        {
            return new Url { String = s };
        }
    }

    [Serializable]
    public class UrlObject
    {
        [SerializeField] private string m_raw;

        [SerializeField] private string m_hash;

        [SerializeField] private string m_protocol;

        [SerializeField] private Host m_host;

        [SerializeField] private PathList m_pathList;

        [SerializeField] private string m_port;

        [SerializeField] private List<QueryParam> m_query;

        [SerializeField] private List<Variable> m_variable;


        [JsonProperty("raw", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Raw
        {
            get => m_raw;
            set => m_raw = value;
        }

        /// <summary>
        ///     Contains the URL fragment (if any). Usually this is not transmitted
        ///     over the network, but it could be useful to store this in some
        ///     cases.
        /// </summary>
        [JsonProperty("hash", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Hash
        {
            get => m_hash;
            set => m_hash = value;
        }

        [JsonProperty("protocol", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Protocol
        {
            get => m_protocol;
            set => m_protocol = value;
        }

        [JsonProperty("host", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public Host Host
        {
            get => m_host;
            set => m_host = value;
        }

        [JsonProperty("path", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public PathList PathList
        {
            get => m_pathList;
            set => m_pathList = value;
        }

        [JsonProperty("port", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Port
        {
            get => m_port;
            set => m_port = value;
        }

        [JsonProperty("query", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<QueryParam> Query
        {
            get => m_query;
            set => m_query = value;
        }

        /// <summary>
        ///     Postman supports path variables with the syntax
        ///     `/path/:variableName/to/somewhere`. These variables are stored in
        ///     this field.
        /// </summary>
        [JsonProperty("variable", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<Variable> Variable
        {
            get => m_variable;
            set => m_variable = value;
        }
    }

    [Serializable]
    public class QueryParam
    {
        [SerializeField] private string m_key;

        [SerializeField] private string m_value;

        [SerializeField] private BoolWrapper m_disabled;

        [SerializeField] private Description m_description;


        [JsonProperty("description")]
        public Description Description
        {
            get => m_description;
            set => m_description = value;
        }

        [JsonProperty("disabled", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public BoolWrapper Disabled
        {
            get => m_disabled;
            set => m_disabled = value;
        }

        [JsonProperty("key")]
        public string Key
        {
            get => m_key;
            set => m_key = value;
        }

        [JsonProperty("value")]
        public string Value
        {
            get => m_value;
            set => m_value = value;
        }
    }

    [Serializable]
    public class Host : StringObjectWrapper<List<string>>
    {
        public static implicit operator Host(string s)
        {
            return new Host { String = s };
        }

        public static implicit operator Host(List<string> stringArray)
        {
            return new Host { Object = stringArray };
        }
    }

    [Serializable]
    public class PathList : StringObjectWrapper<List<Path>>
    {
        public static implicit operator PathList(List<Path> obj)
        {
            return new PathList { Object = obj };
        }

        public static implicit operator PathList(string s)
        {
            return new PathList { String = s };
        }
    }

    [Serializable]
    public class Path : StringObjectWrapper<PathObject>
    {
        public static implicit operator Path(PathObject obj)
        {
            return new Path { Object = obj };
        }

        public static implicit operator Path(string s)
        {
            return new Path { String = s };
        }
    }

    [Serializable]
    public class PathObject
    {
        [SerializeField] private string m_type;

        [SerializeField] private string m_value;


        [JsonProperty("type", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Type
        {
            get => m_type;
            set => m_type = value;
        }

        [JsonProperty("value", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Value
        {
            get => m_value;
            set => m_value = value;
        }
    }
}