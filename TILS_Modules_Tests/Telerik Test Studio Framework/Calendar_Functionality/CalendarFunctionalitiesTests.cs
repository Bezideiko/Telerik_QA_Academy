using System;
using System.Linq;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.TestTemplates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TILS.TTF.AutomationTests
{
    /// <summary>
    /// Summary description for AdminLogAttendanceTests
    /// </summary>    
    [TestClass]
    public class CalendarFunctionalitiesTests : BaseTest
    {

        #region [Setup / TearDown]

        private TestContext testContextInstance = null;
        /// <summary>
        ///Gets or sets the VS test context which provides
        ///information about and functionality for the
        ///current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
        }


        // Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            #region WebAii Initialization

            // Initializes WebAii manager to be used by the test case.
            // If a WebAii configuration section exists, settings will be
            // loaded from it. Otherwise, will create a default settings
            // object with system defaults.
            //
            // Note: We are passing in a delegate to the VisualStudio
            // testContext.WriteLine() method in addition to the Visual Studio
            // TestLogs directory as our log location. This way any logging
            // done from WebAii (i.e. Manager.Log.WriteLine()) is
            // automatically logged to the VisualStudio test log and
            // the WebAii log file is placed in the same location as VS logs.
            //
            // If you do not care about unifying the log, then you can simply
            // initialize the test by calling Initialize() with no parameters;
            // that will cause the log location to be picked up from the config
            // file if it exists or will use the default system settings (C:\WebAiiLog\)
            // You can also use Initialize(LogLocation) to set a specific log
            // location for this test.

            // Pass in 'true' to recycle the browser between test methods
            Initialize(false, this.TestContext.TestLogsDir, new TestContextWriteLine(this.TestContext.WriteLine));

            // If you need to override any other settings coming from the
            // config section you can comment the 'Initialize' line above and instead
            // use the following:

            /*

            // This will get a new Settings object. If a configuration
            // section exists, then settings from that section will be
            // loaded

            Settings settings = GetSettings();

            // Override the settings you want. For example:
            settings.DefaultBrowser = BrowserType.FireFox;

            // Now call Initialize again with your updated settings object
            Initialize(settings, new TestContextWriteLine(this.TestContext.WriteLine));

            */

            // Set the current test method. This is needed for WebAii to discover
            // its custom TestAttributes set on methods and classes.
            // This method should always exist in [TestInitialize()] method.
            SetTestMethod(this, (string)TestContext.Properties["TestName"]);

            #endregion

            Manager.LaunchNewBrowser();
            Browser browser = Manager.ActiveBrowser;
            browser.ClearCache(ArtOfTest.WebAii.Core.BrowserCacheType.Cookies);
            browser.NavigateTo(@"http://test.example.com/");
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {

            //
            // Place any additional cleanup here
            //

            #region WebAii CleanUp

            // Shuts down WebAii manager and closes all browsers currently running
            // after each test. This call is ignored if recycleBrowser is set
            this.CleanUp();

            #endregion
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            // This will shut down all browsers if
            // recycleBrowser is turned on. Else
            // will do nothing.
            ShutDown();
        }

        #endregion
        [TestMethod]
        public void TC_334_NavigateToCalendarPage()
        {
            Browser browser = Manager.ActiveBrowser;
            browser.Find.ById<HtmlAnchor>("LoginButton").Click();
            browser.Find.ById<HtmlInputText>("UsernameOrEmail").Text = "qawannabe";
            browser.Find.ById<HtmlInputPassword>("Password").Text = "testpass1234";
            browser.Find.ByAttributes<HtmlInputSubmit>("class=submit-button", "type=submit", "value=����").MouseClick();

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            string expected = "qawannabe";
            string actual = browser.Find.ByXPath<HtmlSpan>("//*[@id=\"UserProfile\"]/span").InnerText;
            Assert.AreEqual(expected, actual);

            browser.Find.ById<HtmlAnchor>("CalendarMI").MouseClick();
        }

        [TestMethod]
        public void TC_249_CheckCalendarArrowsFunctionality()
        {
            TC_334_NavigateToCalendarPage();
            Manager.Settings.ExecutionDelay = 1000;
            Browser browser = Manager.ActiveBrowser;

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            var monthBox = browser.Find.ByXPath("//*[@id=\"calendar\"]/table/tbody/tr/td[2]/span/h2");
            while (!monthBox.InnerText.Contains("������ 2014"))
            {
                browser.Find.ByXPath<HtmlSpan>("//*[@id=\"calendar\"]/table/tbody/tr/td[1]/span[2]/span").Click();
                browser.WaitUntilReady();
                monthBox.Refresh();
            }
            monthBox.Refresh();
            Assert.AreEqual(monthBox.InnerText, "������ 2014");

            browser.Find.ByXPath<HtmlSpan>("//*[@id=\"calendar\"]/table/tbody/tr/td[1]/span[1]").Click();

            browser.WaitUntilReady();
            monthBox.Refresh();
            browser.RefreshDomTree();

            string expected = monthBox.InnerText;
            string actual = "�������� 2013";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TC_252_CheckTodayButtonTest()
        {
            TC_334_NavigateToCalendarPage();
            Manager.Settings.ExecutionDelay = 1000;
            Browser browser = Manager.ActiveBrowser;

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            browser.Find.ByContent<HtmlSpan>("���").Click();

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            var dayBox = browser.Find.ByXPath("//*[@id=\"calendar\"]/table/tbody/tr/td[2]/span/h2");
            dayBox.Refresh();

            string expected = browser.Find.ByXPath<HtmlSpan>("//*[@id=\"calendar\"]/table/tbody/tr/td[2]/span").InnerText;
            browser.Find.ByXPath<HtmlSpan>("//*[@id=\"calendar\"]/table/tbody/tr/td[1]/span[2]/span").Click();
            browser.Find.ByXPath<HtmlSpan>("//*[@id=\"calendar\"]/table/tbody/tr/td[1]/span[2]/span").Click();
            browser.WaitUntilReady();
            browser.Find.ByContent<HtmlSpan>("����").Click();

            browser.WaitUntilReady();
            dayBox.Refresh();

            string actual = browser.Find.ByXPath<HtmlSpan>("//*[@id=\"calendar\"]/table/tbody/tr/td[2]/span").InnerText;

            browser.WaitUntilReady();
            dayBox.Refresh();
            browser.RefreshDomTree();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TC_253_CheckFunctionalityForWeekTest()
        {
            TC_334_NavigateToCalendarPage();
            Manager.Settings.ExecutionDelay = 1000;
            Browser browser = Manager.ActiveBrowser;

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            browser.Find.ByContent<HtmlSpan>("�������").Click();

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            var weekBox = browser.Find.ByXPath("//*[@id=\"calendar\"]/table/tbody/tr/td[2]/span/h2");
            weekBox.Refresh();

            string expected = browser.Find.ByXPath<HtmlSpan>("//*[@id=\"calendar\"]/table/tbody/tr/td[2]/span").InnerText;
            browser.Find.ByXPath<HtmlSpan>("//*[@id=\"calendar\"]/table/tbody/tr/td[1]/span[2]/span").Click();
            browser.Find.ByXPath<HtmlSpan>("//*[@id=\"calendar\"]/table/tbody/tr/td[1]/span[2]/span").Click();
            browser.WaitUntilReady();
            browser.Find.ByContent<HtmlSpan>("����").Click();

            browser.WaitUntilReady();
            weekBox.Refresh();

            string actual = browser.Find.ByXPath<HtmlSpan>("//*[@id=\"calendar\"]/table/tbody/tr/td[2]/span").InnerText;

            browser.WaitUntilReady();
            weekBox.Refresh();
            browser.RefreshDomTree();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TC_254_CheckFunctionalityForDaysTest()
        {
            TC_334_NavigateToCalendarPage();
            Manager.Settings.ExecutionDelay = 1000;
            Browser browser = Manager.ActiveBrowser;

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            browser.Find.ByContent<HtmlSpan>("���").Click();

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            var dayBox = browser.Find.ByXPath("//*[@id=\"calendar\"]/table/tbody/tr/td[2]/span/h2");
            dayBox.Refresh();

            string expected = browser.Find.ByXPath<HtmlSpan>("//*[@id=\"calendar\"]/table/tbody/tr/td[2]/span").InnerText;
            browser.Find.ByXPath<HtmlSpan>("//*[@id=\"calendar\"]/table/tbody/tr/td[1]/span[2]/span").Click();
            browser.Find.ByXPath<HtmlSpan>("//*[@id=\"calendar\"]/table/tbody/tr/td[1]/span[2]/span").Click();
            browser.WaitUntilReady();
            browser.Find.ByContent<HtmlSpan>("����").Click();

            browser.WaitUntilReady();
            dayBox.Refresh();

            string actual = browser.Find.ByXPath<HtmlSpan>("//*[@id=\"calendar\"]/table/tbody/tr/td[2]/span").InnerText;

            browser.WaitUntilReady();
            dayBox.Refresh();
            browser.RefreshDomTree();

            Assert.AreEqual(expected, actual);
        }
    }
}
