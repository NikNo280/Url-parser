using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Url_parser
{
    public class UrlParcer: IParce<UrlModel>
    {
        private ILogger logger = LogManager.GetCurrentClassLogger();

        public void SetLogger(ILogger logger)
        {
            this.logger = logger;
        }

        public UrlModel Parce(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                this.logger.Error($"{nameof(source)} is null or empty");
                return null;
            }

            try
            {
                string[] items = source.Split("//")[1].Split("/");
                string hostName = items[0];
                List<string> uri = new List<string>();
                List<(string, string)> parametr = new List<(string, string)>();

                for (int i = 1; i < items.Length; i++)
                {
                    var segment = items[i].Split("?");
                    if (!string.IsNullOrWhiteSpace(segment[0]))
                    {
                        uri.Add(segment[0]);
                    }
                    if (segment.Length > 1)
                    {
                        var keyAndValue = segment[1].Split("=");
                        if (keyAndValue.Length == 2)
                        {
                            parametr.Add((keyAndValue[1], keyAndValue[0]));
                        }
                    }
                }

                this.logger.Info("Parsing was successful");
                return new UrlModel(hostName, uri, parametr);
            }
            catch (Exception e)
            {
                this.logger.Error($"Source have incorrect format, {e.Message}");
                return null;
            }
        }
    }
}
