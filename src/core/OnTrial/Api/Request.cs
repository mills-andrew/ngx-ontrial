using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OnTrial.Api
{
    public class Request
    {
        public EndPoint EndPoint { get; private set; }
        public Dictionary<string, object> Parameters { get; private set; }

        public Request(EndPoint pEndPoint, Dictionary<string, object> pParameters)
        {
            this.EndPoint = pEndPoint;
            this.Parameters = pParameters;
        }

        public string ToJson()
        {
            string json = string.Empty;
            if (this.Parameters.IsNullOrEmpty() == false)
                json = JsonConvert.SerializeObject(this.Parameters);
            return string.IsNullOrEmpty(json) ? "{}" : json;
        }

        public override string ToString()
        {
            string[] urlArray = this.EndPoint.Template.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            for (int x = 0; x < urlArray.Length; x++)
            {
                if (urlArray[x].StartsWith("{") && urlArray[x].EndsWith("}"))
                {
                    string key = urlArray[x].Substring(1, urlArray[x].Length - 2);
                    if (this.Parameters.IsNullOrEmpty() == false)
                    {
                        if (this.Parameters.ContainsKey(key) && this.Parameters[key] != null)
                            urlArray[x] = this.Parameters[key].ToString();
                    }
                }
            }

            return string.Join("/", urlArray);
        }
    }
}
