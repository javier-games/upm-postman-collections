using System;
using Newtonsoft.Json;
using UnityEngine;

namespace BricksBucket.Web.Postman.Models
{
    [Serializable]
    public class Description : StringObjectWrapper<DescriptionObject>
    {
        public static implicit operator Description(DescriptionObject obj)
        {
            return new Description { Object = obj };
        }

        public static implicit operator Description(string s)
        {
            return new Description { String = s };
        }
    }

    [Serializable]
    public class DescriptionObject
    {
        [SerializeField] private string m_content;

        [SerializeField] private string m_type;

        [SerializeField] private SerializedObject m_version;


        [JsonProperty("version")]
        public SerializedObject Version
        {
            get => m_version;
            set => m_version = value;
        }

        /// <summary>
        ///     Holds the mime type of the raw description content. E.g:
        ///     'text/markdown' or 'text/html'. The type is used to correctly
        ///     render the description when generating documentation, or in the
        ///     Postman app.
        /// </summary>
        [JsonProperty("type", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Type
        {
            get => m_type;
            set => m_type = value;
        }

        [JsonProperty("content", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Content
        {
            get => m_content;
            set => m_content = value;
        }
    }
}