
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Url_parser.Writer;

namespace Url_parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<UrlModel>();
            var parcer = new UrlParcer();
            using (StreamReader streamReader = new StreamReader("input.txt", Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(parcer.Parce(line));
                }
            }

            IWriter<UrlModel> writer = new UrlXmlWriter();
            writer.Write(list.ToArray(), "output.xml");
        }
    }
}
