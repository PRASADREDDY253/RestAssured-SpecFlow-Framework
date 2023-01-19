using TechTalk.SpecFlow;

namespace APITests.Hooks
{
    [Binding]
    public sealed class TestInitialize
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeFeature] 
        public static void BeforeFeature()=>Console.WriteLine("This line is executed from Before feature");

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()=>Console.WriteLine("This line is executed from Before scenario");

        [AfterScenario]
        public void AfterScenario()=> Console.WriteLine("This line is executed from After scenario");

        [AfterFeature]
        public static void AfterFeature() => Console.WriteLine("This line is executed from After feature");
    }
}