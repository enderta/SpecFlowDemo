using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.Drivers;


namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class YouteVideoStepDefinitions
    {




        [Given(@"I am on the Youte video page")]
        public void GivenIAmOnTheYouteVideoPage()
        {
          Driver.Initialize();
            Driver.driver.Navigate().GoToUrl("https://www.youtube.com/watch?v=9bZkp7q19f0");

                
                }

        [When(@"I click on the video")]
        public void WhenIClickOnTheVideo()
        {
            ClassicAssert.AreEqual(1, 1);
        }

        [Then(@"I should see the video playing")]
        public void ThenIShouldSeeTheVideoPlaying()
        {
            ClassicAssert.AreEqual(1, 2);
        }
    }
}
