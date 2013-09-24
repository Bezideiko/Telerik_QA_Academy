using System;
using System.Linq;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.TestTemplates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Telerik.WebAii.Controls.Xaml;

namespace TestProject
{
	public abstract class TestClassCore : BaseTest
	{
		public const int DefaultKeyPressDuration = 50;
        public readonly string DefaultTestPagePath = "/RadGridViewTestPage.aspx#/";
		private TestContext testContextInstance = null;
        protected RadGridView gridView;


		public IApplication Application
		{
			get;
			set;
		}

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

        public virtual void InitializeTest()
        {
            var settings = new Settings();

            settings.ClientReadyTimeout = 20000;
            settings.ExecutionDelay = 100;
            settings.ExecuteCommandTimeout = 1000;
            settings.WaitCheckInterval = 500;
            settings.SimulatedMouseMoveSpeed = 0.2f;
            settings.QueryEventLogErrorsOnExit = false;
            settings.AnnotateExecution = false;
            settings.AnnotationMode = AnnotationMode.All;
            settings.LogAnnotations = false;

            settings.Web.DefaultBrowser = BrowserType.InternetExplorer;
            settings.Web.EnableUILessRequestViewing = false;
            settings.Web.EnableScriptLogging = false;
            settings.Web.EnableSilverlight = true;
            settings.Web.RecycleBrowser = true;
            settings.Web.KillBrowserProcessOnClose = true;
            settings.Web.LocalWebServer = LocalWebServerType.AspNetDevelopmentServer;
            settings.Web.BaseUrl = "http://localhost/";
            settings.Web.AspNetDevServerPort = 1236;
            settings.Web.WebAppPhysicalPath = GetExamplesWebFolder();

            this.Initialize(settings, null);
            this.LaunchSilverlightApplication();
            this.InitializeGridView("gridView");
        }

		private string GetExamplesWebFolder()
		{
			var testAssemblyPath = this.GetType().Assembly.Location;
			var testAssemblyFolder = System.IO.Path.GetDirectoryName(testAssemblyPath);

			return testAssemblyFolder;
		}

		protected virtual void LaunchSilverlightApplication()
		{
			var applicationPath = this.DefaultTestPagePath;

            if (Manager.Browsers.Count == 0)
            {
                Manager.LaunchNewBrowser();
            }

            ActiveBrowser.Window.Maximize();
            ActiveBrowser.NavigateTo(applicationPath);
            ActiveBrowser.WaitUntilReady();

			this.Application = ActiveBrowser.SilverlightApps()[0];
		}

        private void InitializeGridView(string gridViewName)
        {
            this.Application.RefreshVisualTrees();
            int i = 0;
            for (i = 1; i <= 100; i++)
            {
                if (Application.Find.AllByName<RadGridView>(gridViewName).Count > 0)
                {
                    break;
                }
                Thread.Sleep(400);
                Application.RefreshVisualTrees();
            }
            Application.Find.ByName<RadGridView>(gridViewName).Wait.ForVisible(20000);

            this.gridView = this.Application.Find.ByName<RadGridView>(gridViewName);
            this.gridView.Refresh();
        }
	}
}