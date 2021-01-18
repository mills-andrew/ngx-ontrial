using Newtonsoft.Json;
using OnTrial.Api;
using OnTrial.MSTest;
using System.Collections.Generic;
using System.IO;

namespace Web.Tests
{
    [TestSuite]
    public class CrudTests
    {
        
        [TestCase]
        public void TEST()
        {
            string baseUrl = "https://dev.azure.com/";
            string uri = "CSC-SCC/AS-OBS%20-%20LTE%20Support%20Applications/_apis/build/builds/5911/artifacts?artifactName=web-app&api-version=5.0";

            ApiClient client = new ApiClient(baseUrl);

            var response = client.SendRequestAsync(ApiMethod.Get, uri).Content.ReadAsStringAsync().Result;
            
        }
    }
}