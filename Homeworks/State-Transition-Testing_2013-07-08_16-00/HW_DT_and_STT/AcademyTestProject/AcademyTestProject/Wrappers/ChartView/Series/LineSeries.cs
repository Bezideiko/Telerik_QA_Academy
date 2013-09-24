using System.Collections.Generic;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;
using System.Linq;

namespace Wrappers.ChartView
{
    /// <summary>
    /// Represents the LineSeries for RadCartesianChart Silverlight control wrapper.
    /// </summary>
    public class LineSeries : ContinuousSeriesBase
    {
        /// <summary>
        /// Initializes a new instance of the LineSeries class.
        /// </summary>
        public LineSeries()
        {
        }

        /// <summary>
        /// Get the Line ZIndex
        /// </summary>
        public int ZIndex
        {
            get
            {
                return this.GetAttachedProperty<int>("System.Windows.Controls.Canvas", "ZIndex");
            }
        }

        /// <summary>
        /// Get the xaml tag of LineSeries.
        /// </summary>
        public override string XamlTag
        {
            get
            {
                return MappingKeys.LineSeriesKey;
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

