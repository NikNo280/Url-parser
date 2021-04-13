using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Url_parser
{
    public class UrlModel
    {
        private string hostName;
        private List<string> uri;
        private List<(string, string)> parameters;

        public UrlModel()
        {
            this.uri = new List<string>();
            this.parameters = new List<(string, string)>();
        }

        public UrlModel(string hostName, List<string> uri, List<(string, string)> parametr)
        {
            this.hostName = hostName;
            this.uri = uri;
            this.parameters = parametr;
        }

        public string HostName 
        { 
            get
            {
                return hostName;
            }
        }

        public int GetCountUri()
        {
            return this.uri.Count;
        }

        public int GetCountParameters()
        {
            return this.parameters.Count;
        }

        public IReadOnlyCollection<string> GetUri()
        {
            return new ReadOnlyCollection<string>(this.uri);
        }

        public IReadOnlyCollection<(string, string)> GetParameters()
        {
            return new ReadOnlyCollection<(string, string)>(this.parameters);
        }
    }
}
