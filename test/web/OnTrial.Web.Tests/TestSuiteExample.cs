using OnTrial.Api;
using OnTrial.MSTest;

namespace Web.Tests
{
    [TestSuite]
    public class TestSuiteExample
    {
        
        [TestCase]
        public void TestCaseExample()
        {
            string baseUrl = "https://dev.azure.com/";
            string uri = "CSC-SCC/AS-OBS%20-%20LTE%20Support%20Applications/_apis/build/builds/5911/artifacts?artifactName=web-app&api-version=5.0";

            ApiClient client = new ApiClient(baseUrl);

            var response = client.SendRequestAsync(ApiMethod.Get, uri).Content.ReadAsStringAsync().Result;
            
        }
    }
}