using System;
using System.Linq;
using System.Windows.Forms;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.TestTemplates;
using ArtOfTest.WebAii.Win32.Dialogs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace TILS.TTF.AutomationTests
{
    /// <summary>
    /// Summary description for AdminLogAttendanceTests
    /// </summary>    
    [TestClass]
    public class StudentSignForCourseTests : BaseTest
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

        public void NavigateToCoursePageTest()
        {
            Browser browser = Manager.ActiveBrowser;

            browser.Find.ById<HtmlAnchor>("LoginButton").Click();
            browser.Find.ById<HtmlInputText>("UsernameOrEmail").Text = "qawannabe";
            browser.Find.ById<HtmlInputPassword>("Password").Text = "testpass1234";
            browser.Find.ByAttributes<HtmlInputSubmit>("class=submit-button", "type=submit", "value=Вход").MouseClick();
            browser.WaitUntilReady();
            browser.RefreshDomTree();

            browser.Find.ByContent<HtmlSpan>("Лектор").MouseHover();
            
            browser.WaitUntilReady();
            browser.RefreshDomTree();

            var menu = browser.Find.ById<HtmlUnorderedList>("Menu");
            var course = menu.Find.ByAttributes<HtmlListItem>("class=k-item k-state-default k-first k-last", "role=menuitem");
            browser.WaitUntilReady();
            browser.RefreshDomTree();
            course.MouseClick();

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            browser.Find.ById<HtmlDiv>("Tabstrip").Find.ByTagIndex<HtmlListItem>("li", 1).Click();
        }

        public void UserAlreadySignedAlertHandler(IDialog dialog)
        {
            string txt = dialog.Window.AllChildren[dialog.Window.AllChildren.Count - 1].Caption;
            Assert.AreEqual<string>("Грешкa:\nТози потребител вече е записал курса!\n", txt);
            Log.WriteLine("Dialog text: " + txt);

            Manager.Desktop.KeyBoard.KeyPress(Keys.Enter);
            dialog.HandleCount++;
        }

        public void InvalidUserAlertHandler(IDialog dialog)
        {
            string txt = dialog.Window.AllChildren[dialog.Window.AllChildren.Count - 1].Caption;
            Assert.AreEqual<string>("Грешкa:\nТакъв потребител не съществува!\n", txt);
            Log.WriteLine("Dialog text: " + txt);

            Manager.Desktop.KeyBoard.KeyPress(Keys.Enter);
            dialog.HandleCount++;
        }

        [TestMethod]
        public void TC_116_StudentRegistrationForCourseWithValidCredentialsTest()
        {
            NavigateToCoursePageTest();
            Manager.Settings.ExecutionDelay = 500;

            Browser browser = Manager.ActiveBrowser;

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            browser.Find.ByContent<HtmlAnchor>("Записване на студент в курса").Click();
            browser.Find.ById<HtmlInputText>("Username").MouseClick();
            browser.Find.ById<HtmlInputText>("Username").Text = "angel.elenkov.7";
            browser.Find.ById<HtmlInputCheckBox>("IsLiveParticipant").MouseClick();
            browser.Find.ById<HtmlInputCheckBox>("CanDoPracticalExam").MouseClick();
            browser.Find.ById<HtmlInputCheckBox>("CanDoTestExam").MouseClick();
            browser.Find.ByAttributes<HtmlAnchor>("class=k-button k-button-icontext k-grid-update", "href=#").MouseClick();


            browser.WaitUntilReady();
            browser.RefreshDomTree();

            string actual = browser.Find.ByXPath<HtmlAnchor>("//*[@id=\"UsersInCoursesGrid\"]/table/tbody/tr/td[1]/a").TextContent;
            string expected = "angel.elenkov.7";

            Assert.AreEqual(expected, actual);

            browser.Find.ById<HtmlAnchor>("ExitMI").MouseClick();
        }

        [TestMethod]
        public void TC_159_StudentRegistrationForCourseWithAlreadySignedStudentTest()
        {
            NavigateToCoursePageTest();
            Manager.Settings.ExecutionDelay = 500;

            Browser browser = Manager.ActiveBrowser;

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            browser.Find.ByContent<HtmlAnchor>("Записване на студент в курса").Click();
            browser.Find.ById<HtmlInputText>("Username").MouseClick();
            browser.Find.ById<HtmlInputText>("Username").Text = "angel.elenkov.7";
            browser.Find.ById<HtmlInputCheckBox>("IsLiveParticipant").MouseClick();
            browser.Find.ById<HtmlInputCheckBox>("CanDoPracticalExam").MouseClick();
            browser.Find.ById<HtmlInputCheckBox>("CanDoTestExam").MouseClick();

            AlertDialog alertDialog = AlertDialog.CreateAlertDialog(browser, DialogButton.OK);
            alertDialog.HandlerDelegate = UserAlreadySignedAlertHandler;
            Manager.DialogMonitor.AddDialog(alertDialog);

            try
            {
                browser.Find.ByAttributes<HtmlAnchor>("class=k-button k-button-icontext k-grid-update", "href=#").MouseClick();
                alertDialog.WaitUntilHandled(2000);
                browser.WaitUntilReady();
                browser.RefreshDomTree();
            }
            catch (TimeoutException)
            {
            }

            Manager.DialogMonitor.RemoveDialog(alertDialog);

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            string actual = browser.Find.ByXPath<HtmlAnchor>("//*[@id=\"UsersInCoursesGrid\"]/table/tbody/tr/td[1]/a").TextContent;
            string expected = "angel.elenkov.7";

            Assert.AreEqual(expected, actual);

            browser.Find.ById<HtmlAnchor>("ExitMI").MouseClick();
        }

        [TestMethod]
        public void TC_160_StudentRegistrationForCourseWithInvalidCredentialsTest()
        {
            NavigateToCoursePageTest();
            Manager.Settings.ExecutionDelay = 500;

            Browser browser = Manager.ActiveBrowser;

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            browser.Find.ByContent<HtmlAnchor>("Записване на студент в курса").Click();
            browser.Find.ById<HtmlInputText>("Username").MouseClick();
            browser.Find.ById<HtmlInputText>("Username").Text = "angel.elenkov.5";
            browser.Find.ById<HtmlInputCheckBox>("IsLiveParticipant").MouseClick();
            browser.Find.ById<HtmlInputCheckBox>("CanDoPracticalExam").MouseClick();
            browser.Find.ById<HtmlInputCheckBox>("CanDoTestExam").MouseClick();

            AlertDialog alertDialog = AlertDialog.CreateAlertDialog(browser, DialogButton.OK);
            alertDialog.HandlerDelegate = InvalidUserAlertHandler;
            Manager.DialogMonitor.AddDialog(alertDialog);

            try
            {
                browser.Find.ByAttributes<HtmlAnchor>("class=k-button k-button-icontext k-grid-update", "href=#").MouseClick();
                alertDialog.WaitUntilHandled(2000);
                browser.WaitUntilReady();
                browser.RefreshDomTree();
            }
            catch (TimeoutException)
            {
            }

            Manager.DialogMonitor.RemoveDialog(alertDialog);

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            browser.Find.ById<HtmlAnchor>("ExitMI").MouseClick();
        }

        [TestMethod]
        public void TC_167_UserWithCheckboxesCheckedInRemovalSuccessfullyTest()
        {
            NavigateToCoursePageTest();
            Manager.Settings.ExecutionDelay = 500;

            Browser browser = Manager.ActiveBrowser;

            browser.WaitUntilReady();
            browser.RefreshDomTree();

            AlertDialog ad = AlertDialog.CreateAlertDialog(ActiveBrowser, DialogButton.OK);
            Manager.DialogMonitor.AddDialog(ad);

            browser.Find.ByXPath<HtmlAnchor>("//*[@id=\"UsersInCoursesGrid\"]/table/tbody/tr/td[30]/a").Click();

            try
            {
                ad.WaitUntilHandled(2000);
            }
            catch (TimeoutException)
            {
            }

            Manager.DialogMonitor.RemoveDialog(ad);

            Assert.IsNull(browser.Find.ByXPath<HtmlAnchor>("//*[@id=\"UsersInCoursesGrid\"]/table/tbody/tr/td[1]/a"));

            browser.Find.ById<HtmlAnchor>("ExitMI").Click();
        }
    }
}
