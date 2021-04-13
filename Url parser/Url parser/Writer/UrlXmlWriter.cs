using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Url_parser.Writer;

namespace Url_parser
{
    public class UrlXmlWriter : IWriter<UrlModel>
    {
        public void Write(UrlModel[] urlModels, string pathTo)
        {
            XDocument xdoc = new XDocument();
            XElement urlAddresses = new XElement("urlAddresses");
            xdoc.Add(urlAddresses);
            foreach (var urlModel in urlModels)
            {
                XElement urlAddress = new XElement("urlAddress");
                XElement host = new XElement("host");
                XAttribute hostName = new XAttribute("name", urlModel.HostName);
                urlAddress.Add(host);

                if (urlModel.GetCountUri() > 0)
                {
                    XElement uri = new XElement("uri");
                    foreach (var item in urlModel.GetUri())
                    {
                        XElement segment = new XElement("segment", item);
                        uri.Add(segment);
                    }

                    urlAddress.Add(uri);
                }

                if (urlModel.GetCountParameters() > 0)
                {
                    XElement parameters = new XElement("parameters");
                    foreach (var item in urlModel.GetParameters())
                    {
                        XElement parametr = new XElement("parametr");
                        XAttribute value = new XAttribute("value", item.Item1);
                        XAttribute key = new XAttribute("key", item.Item2);
                        parametr.Add(key);
                        parametr.Add(value);
                        parameters.Add(parametr);
                    }

                    urlAddress.Add(parameters);
                }

                host.Add(hostName);
                urlAddresses.Add(urlAddress);
            }

            xdoc.Save(pathTo);
        }
    }
}
