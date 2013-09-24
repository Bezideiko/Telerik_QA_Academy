using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.WebAii.Controls.Xaml;
using ArtOfTest.WebAii.Controls.Xaml.Wpf;

namespace TestProject
{
    [TestClass]
    public class SelectionTests : GridViewBaseTest
    {
        [TestInitialize]
        public override void InitializeTest()
        {
            base.InitializeTest();
        }
        
        //HINTS
        //Sets the SelectionMode toSingle
        //this.SelectionModeCombo.SelectedIndex = 0; 
        //Sets the SelectionMode Multiple
        //this.SelectionModeCombo.SelectedIndex = 1; 
        //Sets the SelectionMode Extended 
        //this.SelectionModeCombo.SelectedIndex = 2; 

        //Sets the SelectionUnit to Cell
        //this.SelectionUnitCombo.SelectedIndex = 0;
        //Sets the SelectionUnit to FullRow
        //this.SelectionUnitCombo.SelectedIndex = 1; 

        //Sets the property CanUserSelect
        //this.CanUserSelectCheckBox.IsChecked = false;

        //There is an IList collection of Rows
        //Every row can be accessed by its index
        //Each row has an IList collection of Cells
        //Every cell can be accessed by its index

        [TestMethod]
        public void SingleFullRow()
        {
            this.SelectionModeCombo.SelectedIndex = 0;
            this.SelectionUnitCombo.SelectedIndex = 1;
           
            GridViewRow row = this.gridView.Rows[1];
            row.User.Click();
            bool isSelected = row.IsSelected;
            Assert.IsTrue(isSelected);
        }

        [TestMethod]
        public void MultipleFullRow()
        {
            this.SelectionModeCombo.SelectedIndex = 1;
            this.SelectionUnitCombo.SelectedIndex = 1;

            GridViewRow firstRow = this.gridView.Rows[0];
            firstRow.User.Click();
            bool isSelected = firstRow.IsSelected;
            Assert.IsTrue(isSelected);

            GridViewRow secondRow = this.gridView.Rows[1];
            secondRow.User.Click();
            isSelected = secondRow.IsSelected;
            Assert.IsTrue(isSelected);           
        }

        [TestMethod]
        public void MultipleMixed()
        {
            this.SelectionModeCombo.SelectedIndex = 1;
            this.SelectionUnitCombo.SelectedIndex = 2;

            GridViewRow firstRow = Application.Find.ByAutomationId<GridViewRow>("Row_0");
            GridViewCell firstRowCell = this.gridView.Rows[0].Cells[0];
            firstRowCell.User.Click(ArtOfTest.WebAii.Core.MouseClickType.LeftClick, -68, -1, ArtOfTest.Common.OffsetReference.AbsoluteCenter, ArtOfTest.Common.ActionPointUnitType.Pixel);

            bool isSelected = firstRow.IsSelected;
            Assert.IsTrue(isSelected);

            GridViewCell secondRowCell = this.gridView.Rows[1].Cells[1];
            secondRowCell.User.Click();
            isSelected = secondRowCell.IsSelected;
            Assert.IsTrue(isSelected);
        }
    }
}
