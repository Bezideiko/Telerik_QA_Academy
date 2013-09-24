using System;
using System.Linq;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.TestTemplates;
using ArtOfTest.WebAii.Win32.Dialogs;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TILS.TTF.AutomationTests
{
    /// <summary>
    /// Summary description for AdminLogAttendanceTests
    /// </summary>    
    [TestClass]
    public class AdminAttendanceLogTests : BaseTest
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
            browser.NavigateTo(@"http://test.telerikacademy.com/");
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
        public void TC_171_CreationOfNewAttendanceTest()
        {
            Manager.Settings.ExecutionDelay = 500;

            Browser browser = TC_344_NavigateToAttendancesTest();
            browser.Find.ByContent<HtmlAnchor>("Създаване на присъствие").Click();
            browser.Find.ByAttributes<HtmlSpan>("class=k-icon k-i-arrow-s", "unselectable=on").Click();
            browser.Find.ById<HtmlDiv>("DeviceId-list").Find.ByContent<HtmlListItem>("Ultimate - GreatHallDevice").MouseClick();
            browser.Find.ById<HtmlInputText>("Username").MouseClick();
            browser.Find.ById<HtmlInputText>("Username").Text = "qawannabe";
            browser.Find.ByContent<HtmlAnchor>("Update").Click();

            string expected = "Ultimate - GreatHallDevice";
            string actual = browser.Find.ById<HtmlDiv>("DataGrid").Find.ByContent<HtmlTableCell>("Ultimate - GreatHallDevice")
                .InnerText;

            Assert.AreEqual(expected, actual);

            bool isNull = false;
            try
            {
                browser.Find.ByAttributes<HtmlAnchor>(@"class=usernameToolTip", "target=_blank", "href=/Users/qawannabe", "data-username=qawannabe");
            }
            catch (NullReferenceException)
            {
                isNull = true;
            }

            Assert.IsFalse(isNull);
        }

        [TestMethod]
        public void TC_224_ChangeDeviceTest()
        {
            Manager.Settings.ExecutionDelay = 500;

            Browser browser = TC_344_NavigateToAttendancesTest();

            string oldDeviceValueActual = browser.Find.ByXPath<HtmlTableCell>("//*[@id=\"DataGrid\"]/table/tbody/tr[1]/td[2]").TextContent;

            browser.RefreshDomTree();
            browser.WaitUntilReady();

            var modifyButton = browser.Find.ByXPath<HtmlAnchor>("//*[@id=\"DataGrid\"]/table/tbody/tr[1]/td[5]/a");
            modifyButton.Click();
            
            browser.Find.ByAttributes<HtmlSpan>("class=k-icon k-i-arrow-s", "unselectable=on").Click();
            browser.Find.ById<HtmlDiv>("DeviceId-list").Find.ByContent<HtmlListItem>("Light - Buffer").MouseClick();
            browser.Find.ByContent<HtmlAnchor>("Update").Click();

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            string newDeviceValueActual = browser.Find.ByXPath<HtmlTableCell>("//*[@id=\"DataGrid\"]/table/tbody/tr[1]/td[2]").TextContent;

            Assert.AreNotEqual(oldDeviceValueActual, newDeviceValueActual);
        }

        [TestMethod]
        public void TC_225_ChangeUserTest()
        {
            Manager.Settings.ExecutionDelay = 500;

            Browser browser = TC_344_NavigateToAttendancesTest();

            var modifyButton = browser.Find.ByXPath<HtmlAnchor>("//*[@id=\"DataGrid\"]/table/tbody/tr[1]/td[5]/a");
            modifyButton.Click();

            browser.Find.ById<HtmlInputText>("Username").Text = "";
            browser.Find.ById<HtmlInputText>("Username").MouseClick();
            Manager.Desktop.KeyBoard.TypeText("angel.elenkov.7", 10, 50);
            browser.Find.ById<HtmlInputText>("Username").MouseClick();
            browser.Find.ByContent<HtmlAnchor>("Update").MouseClick();
            
            browser.RefreshDomTree();
            browser.Refresh();
            browser.WaitUntilReady();

            string oldUserValueActual = browser.Find.ByXPath<HtmlAnchor>("//*[@id=\"DataGrid\"]/table/tbody/tr[1]/td[3]/a").TextContent;
            string oldUserValueExpected = "angel.elenkov.7";

            Assert.AreEqual(oldUserValueExpected, oldUserValueActual);
        }

        [TestMethod]
        public void TC_228_ChangeDateTimeTest()
        {
            Manager.Settings.ExecutionDelay = 500;

            Browser browser = TC_344_NavigateToAttendancesTest();

            string oldDateTimeValue = browser.Find.ByXPath<HtmlTableCell>("//*[@id=\"DataGrid\"]/table/tbody/tr/td[4]").TextContent;

            browser.RefreshDomTree();
            browser.WaitUntilReady();

            var modifyButton = browser.Find.ByXPath<HtmlAnchor>("//*[@id=\"DataGrid\"]/table/tbody/tr[1]/td[5]/a");
            modifyButton.Click();

            browser.Find.ById<HtmlInputText>("Time").Text = "";
            browser.Find.ById<HtmlInputText>("Time").MouseClick();
            Manager.Desktop.KeyBoard.TypeText("01/01/2014 08:30:00", 10, 50);
            browser.Find.ById<HtmlInputText>("Username").MouseClick();
            browser.Find.ByContent<HtmlAnchor>("Update").MouseClick();

            browser.RefreshDomTree();
            browser.WaitUntilReady();


            string newDateTimeValue = browser.Find.ByXPath<HtmlTableCell>("//*[@id=\"DataGrid\"]/table/tbody/tr/td[4]").TextContent;
            Assert.AreNotEqual(oldDateTimeValue, newDateTimeValue);
        }

        [TestMethod]
        public void TC_232_ApplyMultipleChangesAtOnceTest()
        {
            Manager.Settings.ExecutionDelay = 500;

            Browser browser = TC_344_NavigateToAttendancesTest();

            string oldDeviceValue = browser.Find.ByXPath<HtmlTableCell>("//*[@id=\"DataGrid\"]/table/tbody/tr[1]/td[2]").TextContent;
            string oldDateTimeValue = browser.Find.ByXPath<HtmlTableCell>("//*[@id=\"DataGrid\"]/table/tbody/tr/td[4]").TextContent;

            browser.RefreshDomTree();
            browser.WaitUntilReady();

            var modifyButton = browser.Find.ByXPath<HtmlAnchor>("//*[@id=\"DataGrid\"]/table/tbody/tr[1]/td[5]/a");
            modifyButton.Click();

            browser.Find.ByAttributes<HtmlSpan>("class=k-icon k-i-arrow-s", "unselectable=on").Click();
            browser.Find.ById<HtmlDiv>("DeviceId-list").Find.ByContent<HtmlListItem>("Light - Buffer").MouseClick();

            browser.Find.ById<HtmlInputText>("Username").Text = "";
            browser.Find.ById<HtmlInputText>("Username").MouseClick();
            Manager.Desktop.KeyBoard.TypeText("angel.elenkov.7", 10, 50);
            browser.Find.ById<HtmlInputText>("Username").MouseClick();

            browser.Find.ById<HtmlInputText>("Time").Text = "";
            browser.Find.ById<HtmlInputText>("Time").MouseClick();
            Manager.Desktop.KeyBoard.TypeText("01/01/2015 08:30:00", 10, 50);
            browser.Find.ById<HtmlInputText>("Username").MouseClick();

            browser.RefreshDomTree();
            browser.WaitUntilReady();

            browser.Find.ByContent<HtmlAnchor>("Update").MouseClick();

            browser.RefreshDomTree();
            browser.WaitUntilReady();

            string newDeviceValue = browser.Find.ByXPath<HtmlTableCell>("//*[@id=\"DataGrid\"]/table/tbody/tr[1]/td[2]").TextContent;
            string newUserValue = browser.Find.ByXPath<HtmlAnchor>("//*[@id=\"DataGrid\"]/table/tbody/tr[1]/td[3]/a").TextContent;
            string newDateTimeValue = browser.Find.ByXPath<HtmlTableCell>("//*[@id=\"DataGrid\"]/table/tbody/tr/td[4]").TextContent;
            Assert.AreNotEqual(oldDeviceValue, newDeviceValue);
            Assert.AreEqual("angel.elenkov.7", newUserValue);
            Assert.AreNotEqual(oldDateTimeValue, newDateTimeValue);
        }

        [TestMethod]
        public void TC_220_RemoveValidAttendanceTest()
        {
            Manager.Settings.ExecutionDelay = 500;

            Browser browser = TC_344_NavigateToAttendancesTest();

            AlertDialog ad = AlertDialog.CreateAlertDialog(ActiveBrowser, DialogButton.OK);
            Manager.DialogMonitor.AddDialog(ad);

            string oldID = browser.Find.ByXPath<HtmlTableCell>("//*[@id=\"DataGrid\"]/table/tbody/tr[1]/td[1]").InnerText;
            browser.Find.ByXPath<HtmlAnchor>("//*[@id=\"DataGrid\"]/table/tbody/tr[1]/td[6]/a").Click();
            try
            {
                ad.WaitUntilHandled(2000);
            }
            catch (TimeoutException)
            {
            }

            Manager.DialogMonitor.RemoveDialog(ad);

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            string newID = browser.Find.ByXPath<HtmlTableCell>("//*[@id=\"DataGrid\"]/table/tbody/tr[1]/td[1]").InnerText;

            Assert.AreNotEqual(oldID, newID);
        }

        [TestMethod]
        public Browser TC_344_NavigateToAttendancesTest()
        {
            Browser browser = Manager.ActiveBrowser;
            browser.Find.ById<HtmlAnchor>("LoginButton").Click();
            browser.Find.ById<HtmlInputText>("UsernameOrEmail").Text = "qawannabe";
            browser.Find.ById<HtmlInputPassword>("Password").Text = "testpass1234";
            browser.Find.ByAttributes<HtmlInputSubmit>("class=submit-button", "type=submit", "value=Вход").MouseClick();

            browser.RefreshDomTree();
            browser.WaitUntilReady();

            browser.Find.ByContent<HtmlAnchor>("Админ").Click();
            browser.Find.ByContent<HtmlAnchor>("Присъствия").Click();
            string actual = Find.ByXPath("//*[@id=\"MainContent\"]/h2").InnerText;
            string expected = "Присъствия";

            Assert.AreEqual(expected, actual);

            return browser;
        }
    }
}
