using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtOfTest.WebAii.Core;
using TechTalk.SpecFlow;

namespace FrameworkHomework
{
    [Binding]
    public class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            Manager myManager = new Manager(false);
            myManager.Settings.ExecutionDelay = 1000;
            myManager.Start();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (Manager.Current != null)
            {
                Manager.Current.Dispose();
            }
        }
    }
}
