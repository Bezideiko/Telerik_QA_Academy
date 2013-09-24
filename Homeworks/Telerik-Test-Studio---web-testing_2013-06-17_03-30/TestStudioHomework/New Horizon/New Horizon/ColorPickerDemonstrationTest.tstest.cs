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
        

    public class ColorPickerDemonstrationTest : BaseWebAiiTest
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
    
        //[CodedStep(@"Verify 'ColorAndBackground:BackgroundColor' style 'Exact' '#FF6633' on 'SampleContentSample1Div' - DataDriven: [$(colorValue)] - DataDriven: [$(colorValue)]")]
        //public void ColorPickerDemonstrationTest_CodedStep()
        //{
            //// Verify 'ColorAndBackground:BackgroundColor' style 'Contains' '#FF6633' on 'SampleContentSample1Div' - DataDriven: [$(colorValue)]
            //Pages.ColorPickerSample.SampleContentSample1Div.AssertStyle().ColorAndBackground(ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts.HtmlStyleColorAndBackground.BackgroundColor, "#FF6633", ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts.HtmlStyleType.Computed, ArtOfTest.Common.StringCompareType.Contains);
            
        //}
    
        //[CodedStep(@"Verify 'ColorAndBackground:BackgroundColor' style 'Contains' '#FF6633' on 'SampleContentSample1Div'")]
        //public void ColorPickerDemonstrationTest_CodedStep()
        //{
            //// Verify 'ColorAndBackground:BackgroundColor' style 'Contains' '#FF6633' on 'SampleContentSample1Div'
            //Pages.ColorPickerSample.SampleContentSample1Div.AssertStyle().ColorAndBackground(ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts.HtmlStyleColorAndBackground.BackgroundColor, "#FF6633", ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts.HtmlStyleType.Inline, ArtOfTest.Common.StringCompareType.Contains);
            
        //}
    }
}
