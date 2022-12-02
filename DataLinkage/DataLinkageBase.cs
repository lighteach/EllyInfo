using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;

namespace DataLinkage
{
    public class DataLinkageBase
    {
        public HtmlDocument GetHtmlDocument(string targetUrl)
        {
            HtmlDocument document = new HtmlDocument();
            using (HttpClient client = new HttpClient())
            {
                string html = client.GetStringAsync(targetUrl).GetAwaiter().GetResult();
                if (!string.IsNullOrEmpty(html))
                {
                    document.LoadHtml(html);
                }
            }

            return document;
        }

        public HtmlDocument GetHtmlDocument_V2(string targetUrl)
        {
            HtmlDocument document = new HtmlDocument();

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(targetUrl);
            req.Method = "GET";
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                using (Stream strm = resp.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(strm))
                    {
                        string html = reader.ReadToEnd();
                        if (!string.IsNullOrEmpty(html))
                        {
                            document.LoadHtml(html);
                        }
                    }
                }
            }

            return document;
        }
    }
}