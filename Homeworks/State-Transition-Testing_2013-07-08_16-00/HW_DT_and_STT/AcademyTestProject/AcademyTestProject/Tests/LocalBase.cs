using System.Collections.Generic;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Silverlight;
using Wrappers;
using ArtOfTest.WebAii.Silverlight.UI;
using ArtOfTest.WebAii.TestTemplates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class LocalBase : BaseTest
    {
        public LocalBase()
        {

        }

        /// <summary>
        /// Return the element with specified name as the desired type.
        /// </summary>
        /// <typeparam name="T">The desired type of element to return.</typeparam>
        /// <param name="elementName">The element's name.</param>
        /// <returns>The object if found.</returns>
        public T FindByName<T>(string elementName)
             where T : ArtOfTest.WebAii.Controls.Xaml.IFrameworkElement
        {
            return app.Find.ByName<T>(elementName);
        }

        /// <summary>
        /// Return the element with specified name as the desired type.
        /// </summary>
        /// <param name="elementName"></param>
        public ArtOfTest.WebAii.Controls.Xaml.IFrameworkElement FindByName(string elementName)
        {
            return app.Find.ByName(elementName);
        }

        /// <summary>
        /// Find the first control of certain type.
        /// </summary>
        /// <typeparam name="T">The type of the control</typeparam>
        /// <param name="elementName">The name of the control</param>
        /// <returns>The control or null if not found.</returns>
        public T FindByType<T>()
             where T : ArtOfTest.WebAii.Controls.Xaml.IFrameworkElement
        {
            return app.Find.ByType<T>();
        }
        /// <summary>
        /// Refreshes the main visual tree for the application as well as any open Popup visual trees.
        /// </summary>
        public void RefreshVisualTrees()
        {
            app.RefreshVisualTrees();
        }

        protected SilverlightApp app;

        private TestContext testContextInstance = null;
        /// <summary>
        /// Gets or sets the VS test context which provides
        /// information about and functionality for the 
        /// current test run.
        /// </summary>
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

        //Use ClassCleanup to run code after all tests in a class have run. Call it in the derived class 
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            ShutDown();
        }

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Settings settings = GetSettings();
            this.ConfigureSettings(settings);
            settings.Validate();

            try
            {
                settings.Validate();
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                // directory is wrong, this is probably a TFS build
                settings.Web.WebAppPhysicalPath = GetExamplesWebFolder(true);
            }
            Initialize(settings, null);
        }

        protected virtual void ConfigureSettings(Settings settings)
        {
            settings.Web.EnableSilverlight = true;
            settings.Web.RecycleBrowser = true;

            // settings.UseHttpProxy = false;
            settings.Web.DefaultBrowser = BrowserType.InternetExplorer;
            settings.ClientReadyTimeout = 20000;
            settings.ExecutionDelay = 100;
            settings.ExecuteCommandTimeout = 60000;
            settings.WaitCheckInterval = 500;
            settings.SimulatedMouseMoveSpeed = 0.5f;

            settings.Web.EnableUILessRequestViewing = false;
            settings.QueryEventLogErrorsOnExit = false;
            settings.Web.EnableScriptLogging = false;
            settings.AnnotateExecution = false;
            settings.AnnotationMode = AnnotationMode.NativeOnly;
            settings.UnexpectedDialogAction = UnexpectedDialogAction.HandleAndContinue;

            //settings.Web.LocalWebServer = LocalWebServerType.None;
            settings.Web.BaseUrl = "http://localhost:56028";
            //settings.Web.AspNetDevServerPort = 15478;

            settings.Web.WebAppPhysicalPath = GetExamplesWebFolder(false);
        }

        /// <summary>
        /// This method get the examples Web folder using the test project directory. 
        /// This is highly dependent on the infrastructure in use. 
        /// In this case, we are using the VSTS TestContext to get the folder. 
        /// </summary>
        /// <returns></returns>
        private string GetExamplesWebFolder(bool isTfsBuild)
        {
            string pathToCombine = isTfsBuild ? @"..\..\Sources\WebAii_XAML_Nightly\XAML\" : @"..\..\..\";
            string outDir = System.IO.Path.Combine(this.TestContext.TestDir, pathToCombine);
            string root = System.IO.Path.GetFullPath(outDir);
            //return root + "Telerik.WebAii.Controls.Xaml.ExamplesWeb";
            return root + "X3_Tests.Web";
        }

        protected virtual SilverlightApp LaunchInitialize(string demoPath)
        {
            Manager.LaunchNewBrowser();
            ActiveBrowser.NavigateTo(demoPath);
            this.ActiveBrowser.WaitUntilReady();
            this.app = ActiveBrowser.SilverlightApps()[0];
            return this.app;
        }        
              
        /// <summary>
        /// Get the first text block text of the given element.
        /// </summary>
        /// <param name="element">The element to get the text from.</param>
        /// <returns>The first text block text of the given element.</returns>
        protected string GetFirstText(FrameworkElement element)
        {
            IList<TextBlock> textBlocks = element.Find.AllByType<TextBlock>();
            return textBlocks.Count == 0 ? null : textBlocks[0].Text;
        }
    }
}


