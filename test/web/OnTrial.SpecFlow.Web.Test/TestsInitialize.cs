using OnTrial.MSTest;
using OnTrial.MSTest.Web;
using TechTalk.SpecFlow;

namespace OnTrial.SpecFlow.Web.Test
{
    [Binding]
    [TestSuite]
    public class TestsInitialize : DefaultWebTestBase
    {
        [BeforeTestRun(Order = 1)]
        public static void PreBeforeTestRun()
        {
        }

        [AfterTestRun(Order = 1)]
        public static void PreAfterTestRun()
        {
        }

        [BeforeFeature(Order = 1)]
        public static void PreBeforeFeatureArrange()
        {
        }

        [BeforeFeature(Order = 100)]
        public static void PostBeforeFeatureArrange(FeatureContext featureContext)
        {
        }

        [BeforeFeature(Order = 101)]
        public static void PreBeforeFeatureAct(FeatureContext featureContext)
        {
        }

        [BeforeFeature(Order = 200)]
        public static void PostBeforeFeatureAct(FeatureContext featureContext)
        {
        }
    }
}