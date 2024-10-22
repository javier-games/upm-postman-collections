using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace BricksBucket.Postman
{
    public enum AuthType
    {
        NULL,
        NO_AUTH,
        API_KEY,
        AWS_V4,
        BASIC,
        BEARER,
        DIGEST,
        HAWK,
        NTLM,
        OAUTH1,
        OAUTH2
    }

    [Serializable]
    public class Auth
    {
        [SerializeField] private AuthType m_type;

        [SerializeField] private SerializedObject m_noAuth;

        [SerializeField] private List<ApiKeyElement> m_apiKey;

        [SerializeField] private List<ApiKeyElement> m_basic;

        [SerializeField] private List<ApiKeyElement> m_bearer;

        [SerializeField] private List<ApiKeyElement> m_awsV4;

        [SerializeField] private List<ApiKeyElement> m_digest;

        [SerializeField] private List<ApiKeyElement> m_hawk;

        [SerializeField] private List<ApiKeyElement> m_ntlm;

        [SerializeField] private List<ApiKeyElement> m_oauth1;

        [SerializeField] private List<ApiKeyElement> m_oauth2;


        [JsonProperty("type", Required = Required.Always)]
        public AuthType Type
        {
            get => m_type;
            set => m_type = value;
        }

        [JsonProperty("noauth")]
        public SerializedObject NoAuth
        {
            get => m_noAuth;
            set => m_noAuth = value;
        }

        [JsonProperty("apikey", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiKeyElement> ApiKey
        {
            get => m_apiKey;
            set => m_apiKey = value;
        }

        [JsonProperty("basic", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiKeyElement> Basic
        {
            get => m_basic;
            set => m_basic = value;
        }

        [JsonProperty("bearer", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiKeyElement> Bearer
        {
            get => m_bearer;
            set => m_bearer = value;
        }

        [JsonProperty("awsv4", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiKeyElement> AwsV4
        {
            get => m_awsV4;
            set => m_awsV4 = value;
        }

        [JsonProperty("digest", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiKeyElement> Digest
        {
            get => m_digest;
            set => m_digest = value;
        }

        [JsonProperty("hawk", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiKeyElement> Hawk
        {
            get => m_hawk;
            set => m_hawk = value;
        }

        [JsonProperty("ntlm", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiKeyElement> Ntlm
        {
            get => m_ntlm;
            set => m_ntlm = value;
        }

        [JsonProperty("oauth1", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiKeyElement> Oauth1
        {
            get => m_oauth1;
            set => m_oauth1 = value;
        }

        [JsonProperty("oauth2", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiKeyElement> Oauth2
        {
            get => m_oauth2;
            set => m_oauth2 = value;
        }
    }

    [Serializable]
    public class ApiKeyElement
    {
        [SerializeField] private string m_type;

        [SerializeField] private string m_key;

        [SerializeField] private SerializedObject m_value;


        [JsonProperty("type", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Type
        {
            get => m_type;
            set => m_type = value;
        }

        [JsonProperty("key", Required = Required.Always)]
        public string Key
        {
            get => m_key;
            set => m_key = value;
        }

        [JsonProperty("value")]
        public SerializedObject Value
        {
            get => m_value;
            set => m_value = value;
        }
    }
}