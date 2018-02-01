using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

namespace CometD.NetCore.Client.Transport
{
    public abstract class HttpClientTransport : ClientTransport
    {
        public string Url { protected get; set; }
        public CookieCollection CookieCollection { protected get; set; }
        public WebHeaderCollection HeaderCollection { protected get; set; }


        protected HttpClientTransport(string name, IDictionary<string, object> options)
            : base(name, options)
        {
            SetHeaderCollection(new WebHeaderCollection());
        }

        protected internal void AddCookie(Cookie cookie)
        {
            var cookieCollection = CookieCollection;
            cookieCollection?.Add(cookie);
        }
        protected WebHeaderCollection GetHeaderCollection()
        {
            return HeaderCollection;
        }

        public void SetHeaderCollection(WebHeaderCollection headerCollection)
        {
            this.HeaderCollection = headerCollection;
        }

        protected internal void AddHeaders(NameValueCollection headers)
        {
            WebHeaderCollection headerCollection = this.HeaderCollection;
            if (HeaderCollection != null)
                HeaderCollection.Add(headers);
        }
    }
}
