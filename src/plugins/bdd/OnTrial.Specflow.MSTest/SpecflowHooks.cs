using TechTalk.SpecFlow;

namespace OnTrial.Specflow.MSTest
{
    [Binding]
    public class SpecflowHooks
    {
        static SpecflowHooks()
        {
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
        }

        [BeforeScenario(Order = 1)]
        public void PreBeforeScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
        }

        [BeforeScenario(Order = 100)]
        public void PostBeforeScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
        }

        [AfterScenario(Order = 1)]
        public void PreAfterScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
        }

        [AfterScenario(Order = 100)]
        public void PostAfterScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
        }
    }
}
