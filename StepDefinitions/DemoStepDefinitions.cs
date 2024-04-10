using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using SpecFlowProject1.Drivers;
using TechTalk.SpecFlow;

[Binding]
public class DemoSteps
{
    string title;

    [Given(@"I am on the demo page (.*)")]
    public void GivenIAmOnTheDemoPage(string url)
    {

        Driver.Initialize();
        Driver.driver.Navigate().GoToUrl(url);
        title = Driver.driver.Title;
        Driver.Shutdown();

    }

    [Then(@"the (.*) of page")]
    public void ThenTheTitleOfPage(string title)
    {
        ClassicAssert.AreEqual(title, this.title);
    }
}
