using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace BricksBucket.Postman
{
    /// <summary>
    ///     A request represents an HTTP request. If a string, the string is
    ///     assumed to be the request URL and the method is assumed to be 'GET'.
    /// </summary>
    [Serializable]
    public class Request : StringObjectWrapper<RequestObject>
    {
        public static implicit operator Request(RequestObject obj)
        {
            return new Request { Object = obj };
        }

        public static implicit operator Request(string s)
        {
            return new Request { String = s };
        }
    }

    [Serializable]
    public class RequestObject
    {
        [SerializeField] private Url m_url;

        [SerializeField] private Auth m_auth;

        [SerializeField] private ProxyConfig m_proxy;

        [SerializeField] private Certificate m_certificate;

        [SerializeField] private string m_method;

        [SerializeField] private Description m_description;

        [SerializeField] private Header m_header;

        [SerializeField] private Body m_body;


        [JsonProperty("description")]
        public Description Description
        {
            get => m_description;
            set => m_description = value;
        }

        [JsonProperty("method", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Method
        {
            get => m_method;
            set => m_method = value;
        }

        [JsonProperty("url", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public Url Url
        {
            get => m_url;
            set => m_url = value;
        }

        [JsonProperty("auth")]
        public Auth Auth
        {
            get => m_auth;
            set => m_auth = value;
        }

        [JsonProperty("body")]
        public Body Body
        {
            get => m_body;
            set => m_body = value;
        }

        [JsonProperty("header", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public Header Header
        {
            get => m_header;
            set => m_header = value;
        }

        [JsonProperty("certificate", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public Certificate Certificate
        {
            get => m_certificate;
            set => m_certificate = value;
        }

        [JsonProperty("proxy", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public ProxyConfig Proxy
        {
            get => m_proxy;
            set => m_proxy = value;
        }
    }

    [Serializable]
    public class Certificate
    {
        [SerializeField] private string m_name;

        [SerializeField] private List<string> m_matches;

        [SerializeField] private Key m_key;

        [SerializeField] private CertificateSource m_certificateSource;

        [SerializeField] private string m_passphrase;


        [JsonProperty("name", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Name
        {
            get => m_name;
            set => m_name = value;
        }

        [JsonProperty("cert", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public CertificateSource CertificateSource
        {
            get => m_certificateSource;
            set => m_certificateSource = value;
        }

        [JsonProperty("key", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public Key Key
        {
            get => m_key;
            set => m_key = value;
        }

        [JsonProperty("matches", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Matches
        {
            get => m_matches;
            set => m_matches = value;
        }

        [JsonProperty("passphrase", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Passphrase
        {
            get => m_passphrase;
            set => m_passphrase = value;
        }
    }

    [Serializable]
    public class CertificateSource
    {
        [SerializeField] private string m_source;


        [JsonProperty("src")]
        public string Source
        {
            get => m_source;
            set => m_source = value;
        }
    }

    [Serializable]
    public class Key
    {
        [SerializeField] private string m_source;


        [JsonProperty("src")]
        public string Source
        {
            get => m_source;
            set => m_source = value;
        }
    }

    [Serializable]
    public class ProxyConfig
    {
        [SerializeField] private string m_host;

        [SerializeField] private string m_match;

        [SerializeField] private IntegerWrapper m_port;

        [SerializeField] private BoolWrapper m_tunnel;

        [SerializeField] private BoolWrapper m_disabled;


        [JsonProperty("host", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Host
        {
            get => m_host;
            set => m_host = value;
        }

        [JsonProperty("match", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Match
        {
            get => m_match;
            set => m_match = value;
        }

        [JsonProperty("port", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public IntegerWrapper Port
        {
            get => m_port;
            set => m_port = value;
        }

        [JsonProperty("tunnel", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public BoolWrapper Tunnel
        {
            get => m_tunnel;
            set => m_tunnel = value;
        }

        [JsonProperty("disabled", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public BoolWrapper Disabled
        {
            get => m_disabled;
            set => m_disabled = value;
        }
    }
}