using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Silverlight;
using TechTalk.SpecFlow;
using Telerik.WebAii.Controls.Xaml.Wpf;
using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using TechTalk.SpecFlow;
using ArtOfTest.WebAii.Controls.Xaml.Wpf;

namespace FrameworkHomework
{
    [Binding]
    public class StepDefinition
    {
        private static SilverlightApp slApp { get; set; }
        private static Browser browser { get; set; }

        [Given(@"clean calculator")]
        public void GivenCleanCalculator()
        {
            Manager.Current.LaunchNewBrowser(BrowserType.Chrome);
            browser = Manager.Current.ActiveBrowser;
            browser.NavigateTo(@"http://demos.telerik.com/silverlight/#Menu/Configurator");
            browser.WaitUntilReady();
            slApp = browser.SilverlightApps()[0];
        }

        [When(@"I enter (.*)")]
        public void WhenIEnter(string digit)
        {
            var buttonName = "input" + digit + "_Button";
            slApp.Find.ByName<RadButton>(buttonName).User.Click();
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            var buttonName = "Add_Button";
            slApp.Find.ByName<RadButton>(buttonName).User.Click();
        }

        [When(@"I press extraction")]
        public void WhenIPressExtraction()
        {
            var buttonName = "Substract_Button";
            slApp.Find.ByName<RadButton>(buttonName).User.Click();
        }

        [When(@"I press (.*)")]
        public void WhenIPress(string digit)
        {
            var buttonName = "input" + digit + "_Button";
            slApp.Find.ByName<RadButton>(buttonName).User.Click();
        }

        [When(@"I press equal")]
        public void WhenIPressEqual()
        {
            var buttonName = "Equals_Button";
            slApp.Find.ByName<RadButton>(buttonName).User.Click();
        }

        [Then(@"result should be (.*)")]
        public void ThenResultShouldBe(string expected)
        {
            var actual = slApp.Find.ByAutomationId<TextBlock>("58467488").Text;
            Assert.AreEqual(expected, actual);
        }

        [Then(@"extraction works like this")]
        public void ThenExtractionWorksLikeThis(Table table)
        {
            foreach (var row in table.Rows)
            {
                WhenIEnter(row[0]);
                WhenIPressExtraction();
                WhenIEnter(row[1]);
                WhenIPressEqual();
                ThenResultShouldBe(row[2]);
            }
        }
    }
}
