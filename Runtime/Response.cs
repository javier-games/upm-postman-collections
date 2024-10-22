using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace BricksBucket.Postman
{
    [Serializable]
    public class Response : GenericWrapper<ResponseClass>
    {
        public static implicit operator Response(bool value)
        {
            return new Response { Bool = value };
        }

        public static implicit operator Response(int value)
        {
            return new Response { Integer = value };
        }

        public static implicit operator Response(float value)
        {
            return new Response { Float = value };
        }

        public static implicit operator Response(string value)
        {
            return new Response { String = value };
        }

        public static implicit operator Response(ResponseClass value)
        {
            return new Response { Object = value };
        }

        public static implicit operator Response(
            List<ResponseClass> list
        )
        {
            return new Response { Array = list };
        }
    }

    [Serializable]
    public class ResponseClass
    {
        [SerializeField] private string m_id;

        [SerializeField] private Request m_originalRequest;

        [SerializeField] private StringFloatWrapper m_responseTime;

        [SerializeField] private Timings m_timings;

        [SerializeField] private Headers m_header;

        [SerializeField] private List<Cookie> m_cookie;

        [SerializeField] private string m_body;

        [SerializeField] private string m_status;

        [SerializeField] private int m_code;

        [JsonProperty("body")]
        public string Body
        {
            get => m_body;
            set => m_body = value;
        }

        [JsonProperty("code", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public int Code
        {
            get => m_code;
            set => m_code = value;
        }

        [JsonProperty("cookie", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<Cookie> Cookie
        {
            get => m_cookie;
            set => m_cookie = value;
        }

        [JsonProperty("header")]
        public Headers Header
        {
            get => m_header;
            set => m_header = value;
        }

        [JsonProperty("id", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Id
        {
            get => m_id;
            set => m_id = value;
        }

        [JsonProperty("originalRequest", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public Request OriginalRequest
        {
            get => m_originalRequest;
            set => m_originalRequest = value;
        }

        /// <summary>
        ///     The time taken by the request to complete. If a number, the unit
        ///     is milliseconds. If the response is manually created, this can
        ///     be set to `null`.
        /// </summary>
        [JsonProperty("responseTime")]
        public StringFloatWrapper ResponseTime
        {
            get => m_responseTime;
            set => m_responseTime = value;
        }

        [JsonProperty("status", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Status
        {
            get => m_status;
            set => m_status = value;
        }

        [JsonProperty("timings")]
        public Timings Timings
        {
            get => m_timings;
            set => m_timings = value;
        }
    }

    /// <summary>
    ///     A Cookie, that follows the [Google Chrome
    ///     format](https://developer.chrome.com/extensions/cookies).
    /// </summary>
    [Serializable]
    public class Cookie
    {
        [SerializeField] private string m_domain;

        [SerializeField] private StringFloatWrapper m_expires;

        [SerializeField] private string m_maxAge;

        [SerializeField] private BoolWrapper m_hostOnly;

        [SerializeField] private BoolWrapper m_httpOnly;

        [SerializeField] private string m_name;

        [SerializeField] private string m_path;

        [SerializeField] private BoolWrapper m_secure;

        [SerializeField] private BoolWrapper m_session;

        [SerializeField] private string m_value;

        [SerializeField] private List<string> m_extensions;


        [JsonProperty("name", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Name
        {
            get => m_name;
            set => m_name = value;
        }

        [JsonProperty("path", Required = Required.Always)]
        public string Path
        {
            get => m_path;
            set => m_path = value;
        }

        [JsonProperty("domain", Required = Required.Always)]
        public string Domain
        {
            get => m_domain;
            set => m_domain = value;
        }

        [JsonProperty("value", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Value
        {
            get => m_value;
            set => m_value = value;
        }

        [JsonProperty("expires", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public StringFloatWrapper Expires
        {
            get => m_expires;
            set => m_expires = value;
        }

        /// <summary>
        ///     Custom attributes for a cookie go here, such as the [Priority
        ///     Field](https://code.google.com/p/chromium/issues/detail?id=232693)
        /// </summary>
        [JsonProperty("extensions", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Extensions
        {
            get => m_extensions;
            set => m_extensions = value;
        }

        [JsonProperty("hostOnly", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public BoolWrapper HostOnly
        {
            get => m_hostOnly;
            set => m_hostOnly = value;
        }

        [JsonProperty("httpOnly", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public BoolWrapper HttpOnly
        {
            get => m_httpOnly;
            set => m_httpOnly = value;
        }

        [JsonProperty("maxAge", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string MaxAge
        {
            get => m_maxAge;
            set => m_maxAge = value;
        }

        /// <summary>
        ///     Indicates if the 'secure' flag is set on the Cookie, meaning that
        ///     it is transmitted over secure connections only (typically HTTPS).
        /// </summary>
        [JsonProperty("secure", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public BoolWrapper Secure
        {
            get => m_secure;
            set => m_secure = value;
        }

        /// <summary>
        ///     True if the cookie is a session cookie.
        /// </summary>
        [JsonProperty("session", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public BoolWrapper Session
        {
            get => m_session;
            set => m_session = value;
        }
    }

    [Serializable]
    public class Headers : StringObjectWrapper<List<HeaderElement>>
    {
        public static implicit operator Headers(
            List<HeaderElement> anythingArray
        )
        {
            return new Headers { Object = anythingArray };
        }

        public static implicit operator Headers(string s)
        {
            return new Headers { String = s };
        }
    }

    /// <summary>
    ///     No HTTP request is complete without its headers, and the same is
    ///     true for a Postman request. This field is an array containing all
    ///     the headers.
    /// </summary>
    [Serializable]
    public class HeaderElement : StringObjectWrapper<HeaderObject>
    {
        public static implicit operator HeaderElement(HeaderObject obj)
        {
            return new HeaderElement { Object = obj };
        }

        public static implicit operator HeaderElement(string s)
        {
            return new HeaderElement { String = s };
        }
    }

    [Serializable]
    public class Timings : SerializableDictionary<string, SerializedObject>
    {
    }
}