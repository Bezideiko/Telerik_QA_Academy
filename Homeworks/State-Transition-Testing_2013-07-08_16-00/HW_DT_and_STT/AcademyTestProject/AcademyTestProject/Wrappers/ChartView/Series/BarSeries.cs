using System.Collections.Generic;
using System.Linq;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

namespace Wrappers.ChartView
{
    /// <summary>
    /// Represents the BarSeries for RadCartesianChart Silverlight control wrapper.
    /// </summary>
    public class BarSeries : ContentControl
    {
        /// <summary>
        /// Initializes a new instance of the BarSeries class.
        /// </summary>
        public BarSeries()
        {
        }

        /// <summary>
        /// Get the list of Bars.
        /// </summary>
        public IList<ChartViewBarItem> Bars
        {
            get
            {
                return (from border in this.Find.AllByType<Border>()
                        select new ChartViewBarItem(border)).ToList();
            }
        }

        /// <summary>
        /// Get the Bar ZIndex
        /// </summary>
        public int ZIndex
        {
            get
            {
                return this.GetAttachedProperty<int>("System.Windows.Controls.Canvas", "ZIndex");
            }
        }

        /// <summary>
        /// Get the Bars count.
        /// </summary>
        public int BarCount
        {
            get
            {
                return this.Bars.Count;
            }
        }

        /// <summary>
        /// Get the Visible Bars count.
        /// </summary>
        public int VisibleBarsCount
        {
            get
            {
                return (from border in this.Find.AllByType<Border>()
                        select new ChartViewBarItem(border)).Where(bar => bar.Visibility == ArtOfTest.WebAii.Silverlight.UI.Visibility.Visible).ToList().Count;
            }
        }

        /// <summary>
        /// Get the xaml tag of BarSeries.
        /// </summary>
        public override string XamlTag
        {
            get
            {
                return MappingKeys.BarSeriesKey;
            }
        }

        /// <summary>
        /// Assign the reference and perform your custom class initialization.
        /// </summary>
        /// <param name="reference"></param>
        public override void AssignReference(AutomationReference reference)
        {
            // Make sure the base is first assigned.
            base.AssignReference(reference);
        }
    }
}

