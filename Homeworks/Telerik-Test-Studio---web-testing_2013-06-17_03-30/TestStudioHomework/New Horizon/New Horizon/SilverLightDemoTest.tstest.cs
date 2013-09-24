using Telerik.TestingFramework.Controls.KendoUI;
using Telerik.WebAii.Controls.Html;
using Telerik.WebAii.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts;
using ArtOfTest.WebAii.Design;
using ArtOfTest.WebAii.Design.Execution;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

namespace New_Horizon
{

    //
    // You can add custom execution steps by simply
    // adding a void function and decorating it with the [CodedStep] 
    // attribute to the test method. 
    // Those steps will automatically show up in the test steps on save.
    //
    // The BaseWebAiiTest exposes all key objects that you can use
    // to access the current testcase context. [i.e. ActiveBrowser, Find ..etc]
    //
    // Data driven tests can use the Data[columnIndex] or Data["columnName"] 
    // to access data for a specific data iteration.
    //
    // Example:
    //
    // [CodedStep("MyCustom Step Description")]
    // public void MyCustomStep()
    // {
    //        // Custom code goes here
    //      ActiveBrowser.NavigateTo("http://www.google.com");
    //
    //        // Or
    //        ActiveBrowser.NavigateTo(Data["url"]);
    // }
    //
        

    public class SilverLightDemoTest : BaseWebAiiTest
    {
        #region [ Dynamic Pages Reference ]

        private Pages _pages;

        /// <summary>
        /// Gets the Pages object that has references
        /// to all the elements, frames or regions
        /// in this project.
        /// </summary>
        public Pages Pages
        {
            get
            {
                if (_pages == null)
                {
                    _pages = new Pages(Manager.Current);
                }
                return _pages;
            }
        }

        #endregion
        
        // Add your test methods here...
    
        //[CodedStep(@"Verify 'TimeTextTextblock' text Same '08:12:45'", RequiresSilverlight=true)]
        //public void SilverLightDemoTest_CodedStep()
        //{
            //string today = DateTime.Now.ToLongDateString();
            //string[] splittedToday = today.Split(new char[] {' '}, 2);
            //string[] dateWithoutDayOfWeek = splittedToday[1].Split(new char[] { ' ' }, 2);
            //string correctMonth = dateWithoutDayOfWeek[0].Substring(0, 3).ToUpper();
            //string result = correctMonth + " " + dateWithoutDayOfWeek[1];
            //Assert.AreEqual(Pages.TelerikGaugeForSilverlight0.SilverlightApp.DateTextblock.Text, result);
        //}
    
        //[CodedStep(@"Verify TimeTextTextblock.Text 'Equal' 'DateTime.Now.ToString( MMM dd, yyyy).ToUpper()'", RequiresSilverlight=true)]
        //public void SilverLightDemoTest_CodedStep()
        //{
            //// Verify TimeTextTextblock.Text 'Equal' 'DateTime.Now.ToString( "MMM dd, yyyy").ToUpper()'
            //Assert.IsFalse((ArtOfTest.Common.CompareUtils.StringCompare(Pages.TelerikGaugeForSilverlight1.SilverlightApp.TimeTextTextblock.Text, "DateTime.Now.ToString( \"MMM dd, yyyy\").ToUpper()", ArtOfTest.Common.StringCompareType.Exact) == false), string.Format("Verify TimeTextTextblock.Text \'Equal\' \'DateTime.Now.ToString( \"MMM dd, yyyy\").ToU" +
                                    //"pper()\' failed.  Actual value \'{0}\'", Pages.TelerikGaugeForSilverlight1.SilverlightApp.TimeTextTextblock.Text));
            
        //}
    
        [CodedStep(@"Verify 'TimeTextTextblock' text Same '16:17:13'", RequiresSilverlight=true)]
        public void SilverLightDemoTest_CodedStep()
        {
            // Verify 'TimeTextTextblock' text Same 'DateTime.Now.ToString("MMM dd, yyyy").ToUpper()'
            Assert.AreEqual(Pages.TelerikGaugeForSilverlight1.SilverlightApp.TimeTextTextblock.Text, DateTime.Now.ToString("HH:mm:ss").ToUpper());
            
        }
    
        [CodedStep(@"Verify 'JUN172013Textblock' text Same 'JUN 17, 2013'", RequiresSilverlight=true)]
        public void SilverLightDemoTest_CodedStep1()
        {
            // Verify 'JUN172013Textblock' text Same 'JUN 17, 2013'
            Assert.Equals(Pages.TelerikGaugeForSilverlight1.SilverlightApp.JUN172013Textblock.Text, DateTime.Now.ToString("MM dd, yyyy"));
            
        }
    }
}
