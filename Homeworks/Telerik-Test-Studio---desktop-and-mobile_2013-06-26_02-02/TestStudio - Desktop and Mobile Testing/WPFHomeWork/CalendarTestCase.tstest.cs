using Telerik.WebAii.Controls.Xaml.Wpf;
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
using ArtOfTest.WebAii.Wpf;

namespace WPFHomeWork
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
    //      Applications.Spreadsheetexe.Book1__Spreadsheet.InsertTabitem.User.Click();    
    // }
    //
        

    public class CalendarTestCase : BaseWebAiiTest
    {
        #region [ Dynamic Applications Reference ]

        private Applications _applications;

        /// <summary>
        /// Gets the Applications object that has references
        /// to all the elements, windows or regions
        /// in this project.
        /// </summary>
        public Applications Applications
        {
            get
            {
                if (_applications == null)
                {
                    _applications = new Applications(Manager.Current);
                }
                return _applications;
            }
        }

        #endregion
        
        // Add your test methods here...
    
        //[CodedStep(@"New Coded Step")]
        //public void CalendarTestCase_CodedStep()
        //{
            //var month = Applications.WPF_Demosexe.WPF_Controls_Examples__Grid_Chart_Scheduler_Map_Code_Samples.TextTextblock.Text;
            //while(month != "June - 2013")
            //{
                //Applications.WPF_Demosexe.WPF_Controls_Examples__Grid_Chart_Scheduler_Map_Code_Samples.CalendarRadcalendar.ScrollLeft();
                //if (month == "June - 2013")
                //{
                    //break;
                //}
            //}
        //}
    
        //[CodedStep(@"Verify 'TextTextblock' text Same 'June - 2013'")]
        //public void CalendarTestCase_CodedStep1()
        //{
            //// Verify 'TextTextblock' text Same 'June - 2013'
            //Assert.IsFalse((ArtOfTest.Common.CompareUtils.StringCompare(Applications.WPF_Demosexe.WPF_Controls_Examples__Grid_Chart_Scheduler_Map_Code_Samples.TextTextblock.Text, "June - 2013", ArtOfTest.Common.StringCompareType.Same) == false), string.Format("Verify \'TextTextblock\' text Same \'June - 2013\' failed.  Actual value \'{0}\'", Applications.WPF_Demosexe.WPF_Controls_Examples__Grid_Chart_Scheduler_Map_Code_Samples.TextTextblock.Text));
            
        //}
    
        //[CodedStep(@"radcalendar: 'MoveLeft' action.")]
        //public void CalendarTestCase_CodedStep1()
        //{
            //// radcalendar: 'MoveLeft' action.
            
            
        //}
    }
}
