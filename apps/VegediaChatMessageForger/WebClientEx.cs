using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace VegediaChatMessageForger
{
    public class WebClientEx : WebClient
    {
        private bool _AllowAutoRedirect = false;
        public bool AllowAutoRedirect
        {
            get { return _AllowAutoRedirect; }
            set { _AllowAutoRedirect = value; }
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.AllowAutoRedirect = _AllowAutoRedirect;
            return request;
        }
    }
}
