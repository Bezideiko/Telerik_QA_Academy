using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.TestAttributes;
using ArtOfTest.WebAii.TestTemplates;
using ArtOfTest.WebAii.Win32.Dialogs;

using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.WebAii.Controls.Xaml;

namespace FrameworkHomework
{
    /// <summary>
    /// Summary description for RadMenuTests
    /// </summary>
    [TestClass]
    public class RadMenuTests : BaseTest
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

            //
            // Place any additional initialization here
            //

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
        public void RadMenuNotificationTest()
        {
            Manager.Settings.ExecutionDelay = 1000;
            Manager.Settings.Web.EnableSilverlight = true;

            Manager.LaunchNewBrowser();
            ActiveBrowser.NavigateTo(@"http://demos.telerik.com/silverlight/#Menu/Configurator");
            var silverlightApp = ActiveBrowser.SilverlightApps()[0];
            var help = silverlightApp.Find.AllByType<RadMenuItem>()
                .Where(item => item.Text == "Help")
                .FirstOrDefault();
            var messageBox = silverlightApp.Find.AllByType<ContentControl>()
                .Where(item => item.Name == "configurator")
                .FirstOrDefault();
            
            help.User.Click();
            bool textExist = false;

            try
            {
                silverlightApp.Find.ByTextContent("Help has been clicked");
            }
            catch (Exception)
            {
                textExist = true;
            }

            Assert.IsTrue(textExist);
            textExist = false;

            var checkBox = silverlightApp.Find.AllByType<CheckBox>()
                .Where(item => item.Name == "NotifyOnHeaderClick")
                .FirstOrDefault();
            checkBox.User.Click();
            help.User.Click();
            
            try
            {
                silverlightApp.Find.ByTextContent("Help has been clicked");
            }
            catch (Exception)
            {
                textExist = true;
            }

            Assert.IsFalse(textExist);
        }

        [TestMethod]
        public void RadMenuOrientationTest()
        {
            Manager.Settings.Web.EnableSilverlight = true;
            Manager.Settings.ExecutionDelay = 1000;

            Manager.LaunchNewBrowser();
            ActiveBrowser.NavigateTo(@"http://demos.telerik.com/silverlight/#Menu/Configurator");
            var silverlightApp = ActiveBrowser.SilverlightApps()[0];

            var horizontalRadio = silverlightApp.Find.AllByType<RadioButton>()
                .Where(item => item.Name == "HorizontalOrientation")
                .FirstOrDefault();
            var verticalRadio = silverlightApp.Find.AllByType<RadioButton>()
                .Where(item => item.Name == "VerticalOrientation")
                .FirstOrDefault();

            var menu = silverlightApp.Find.ByName<RadMenu>("rootMenu");

            Assert.AreEqual("Horizontal", menu.Orientation.ToString());

            verticalRadio.Check(true);

            Assert.AreEqual("Vertical", menu.Orientation.ToString());
        }

        [TestMethod]
        public void RadMenuOrientationNotMandatoryTest()
        {
            Manager.Settings.Web.EnableSilverlight = true;
            Manager.Settings.ExecutionDelay = 1000;

            Manager.LaunchNewBrowser();
            ActiveBrowser.ClearCache(ArtOfTest.WebAii.Core.BrowserCacheType.Cookies);
            ActiveBrowser.NavigateTo(@"http://demos.telerik.com/silverlight/#Menu/Configurator");
            var slApp = ActiveBrowser.SilverlightApps()[0];

            var menu = slApp.Find.ByName<RadMenu>("rootMenu");

            var file = menu.Find.AllByType<RadMenuItem>()
                .Where<RadMenuItem>(a => a.Text == "File").FirstOrDefault();
            var edit = menu.Find.AllByType<RadMenuItem>()
                .Where<RadMenuItem>(a => a.Text == "Edit").FirstOrDefault();

            if (slApp.Find.ByName<RadioButton>("HorizontalOrientation").IsChecked == false)
            {
                slApp.Find.ByName<RadioButton>("HorizontalOrientation").Check(true);
                Wait.For<RadMenu>(item => item.Orientation.ToString() == "Horizontal", menu, 2000);
            }

            Assert.IsTrue(file.GetRectangle().Y == edit.GetRectangle().Y);

            slApp.Find.ByName<RadioButton>("VerticalOrientation").Check(true);
            Wait.For<RadMenu>(item => item.Orientation.ToString() == "Vertical", menu, 2000);

            Assert.IsTrue(file.GetRectangle().Y < edit.GetRectangle().Y);
        }
    }
}
