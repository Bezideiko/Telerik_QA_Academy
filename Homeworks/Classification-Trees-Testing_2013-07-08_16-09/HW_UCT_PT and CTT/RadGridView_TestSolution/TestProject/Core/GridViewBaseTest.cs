using System.Linq;
using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Core;
using Telerik.WebAii.Controls.Xaml;
using ArtOfTest.WebAii.Silverlight.UI;
using System;

namespace TestProject
{
    public class GridViewBaseTest : TestClassCore
    {
        public ComboBox SelectionModeCombo { get; set; }
        public ComboBox SelectionUnitCombo { get; set; }
        public CheckBox CanUserSelectCheckBox { get; set; }

        public override void InitializeTest()
        {
            base.InitializeTest();
            
            this.SelectionModeCombo = this.Application.Find.ByName<ComboBox>("selectionModeCombo");
            this.SelectionUnitCombo = this.Application.Find.ByName<ComboBox>("selectionUnitCombo");
            this.CanUserSelectCheckBox = this.Application.Find.ByName<CheckBox>("canUserSelectCheckBox");

            this.gridView.EnsureClickable();
        }

        protected GridViewCell GetCellByRowAndCellIndex(string rowIndex, string cellIndex)
        {
            var row = GetRowByIndex(rowIndex);

            switch (cellIndex)
            {
                case "first":
                    return row.Cells.First();
                case "last":
                    return row.Cells.Last();
                default:
                    int index = 0;
                    bool isANumber = Int32.TryParse(cellIndex, out index);
                    if (isANumber)
                    {
                        return row.Cells[index];
                    }
                    else
                    {
                        throw new NotImplementedException("There is no such index implemented.");
                    }
            }
        }

        public GridViewRow GetRowByIndex(string index)
        {
            switch (index)
            {
                case "first":
                    return this.gridView.Rows.First();
                case "last":
                    return this.gridView.Rows.Last();
                default:
                    int rowIndex = int.Parse(index);
                    return this.gridView.Rows[rowIndex];
            }
        }

        public void CheckCheckBoxByName(string name)
        {
            CheckBox checkBox = this.Application.Find.ByName<CheckBox>(name);
            if (checkBox != null)
            {
                checkBox.User.Click();
            }
        }

        public void AssertAllRowsAreNotSelected()
        {
            var areAllRowsSelected = this.gridView.Rows.All((row) => row.IsSelected == true);

            Assert.IsFalse(areAllRowsSelected);
        }

        public void WaitForNoMotion()
        {
            this.gridView.Wait.ForNoMotion(100, 100, 5000);
        }
    }
}