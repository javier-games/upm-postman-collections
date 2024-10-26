using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace BricksBucket.Web.Postman.Models
{
    public enum Mode
    {
        NONE,
        FILE,
        FORM_DATA,
        GRAPHQL,
        RAW,
        URLENCODED
    }

    public enum FormParameterType
    {
        TEXT,
        FILE
    }

    [Serializable]
    public class Body
    {
        [SerializeField] private Mode m_mode;

        [SerializeField] private string m_raw;

        [SerializeField] private GraphQl m_graphql;

        [SerializeField] private List<UrlEncodedParameter> m_urlencoded;

        [SerializeField] private List<FormParameter> m_formData;

        [SerializeField] private File m_file;

        [SerializeField] private BoolWrapper m_disabled;


        [JsonProperty("mode", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public Mode Mode
        {
            get => m_mode;
            set => m_mode = value;
        }

        [JsonProperty("disabled", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public BoolWrapper Disabled
        {
            get => m_disabled;
            set => m_disabled = value;
        }

        [JsonProperty("raw", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Raw
        {
            get => m_raw;
            set => m_raw = value;
        }

        [JsonProperty("graphql", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public GraphQl Graphql
        {
            get => m_graphql;
            set => m_graphql = value;
        }

        [JsonProperty("file", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public File File
        {
            get => m_file;
            set => m_file = value;
        }

        [JsonProperty("formdata", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<FormParameter> FormData
        {
            get => m_formData;
            set => m_formData = value;
        }

        [JsonProperty("urlencoded", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<UrlEncodedParameter> Urlencoded
        {
            get => m_urlencoded;
            set => m_urlencoded = value;
        }
    }

    [Serializable]
    public class File
    {
        [SerializeField] private string m_content;

        [SerializeField] private string m_source;


        [JsonProperty("content", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Content
        {
            get => m_content;
            set => m_content = value;
        }

        [JsonProperty("src")]
        public string Source
        {
            get => m_source;
            set => m_source = value;
        }
    }

    [Serializable]
    public class FormParameter
    {
        [SerializeField] private string m_key;

        [SerializeField] private string m_value;

        [SerializeField] private Source m_source;

        [SerializeField] private BoolWrapper m_disabled;

        [SerializeField] private FormParameterType m_type;

        [SerializeField] private string m_contentType;

        [SerializeField] private Description m_description;


        [JsonProperty("contentType", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string ContentType
        {
            get => m_contentType;
            set => m_contentType = value;
        }

        [JsonProperty("type", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public FormParameterType Type
        {
            get => m_type;
            set => m_type = value;
        }

        [JsonProperty("description")]
        public Description Description
        {
            get => m_description;
            set => m_description = value;
        }

        [JsonProperty("key", Required = Required.Always)]
        public string Key
        {
            get => m_key;
            set => m_key = value;
        }

        [JsonProperty("value", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Value
        {
            get => m_value;
            set => m_value = value;
        }

        [JsonProperty("src")]
        public Source Source
        {
            get => m_source;
            set => m_source = value;
        }

        [JsonProperty("disabled", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public BoolWrapper Disabled
        {
            get => m_disabled;
            set => m_disabled = value;
        }
    }

    [Serializable]
    public class Source : StringObjectWrapper<List<string>>
    {
        public static implicit operator Source(List<string> obj)
        {
            return new Source { Object = obj };
        }

        public static implicit operator Source(string s)
        {
            return new Source { String = s };
        }
    }

    [Serializable]
    public class UrlEncodedParameter
    {
        [SerializeField] private string m_key;

        [SerializeField] private string m_value;

        [SerializeField] private Description m_description;

        [SerializeField] private BoolWrapper m_disabled;


        [JsonProperty("key", Required = Required.Always)]
        public string Key
        {
            get => m_key;
            set => m_key = value;
        }

        [JsonProperty("value", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
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

        [JsonProperty("disabled", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public BoolWrapper Disabled
        {
            get => m_disabled;
            set => m_disabled = value;
        }
    }

    [Serializable]
    public class GraphQl : SerializableDictionary<string, SerializedObject>
    {
    }
}