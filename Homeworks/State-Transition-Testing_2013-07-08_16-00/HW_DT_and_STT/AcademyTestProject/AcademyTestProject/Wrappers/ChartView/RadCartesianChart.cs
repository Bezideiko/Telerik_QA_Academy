using System.Collections.Generic;
using System.Linq;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

namespace Wrappers.ChartView
{ 
    public class RadCartesianChart : ContentControl
    {
        /// <summary>
        /// Initializes a new instance of the RadCartesianChart class.
        /// </summary>
        public RadCartesianChart()
        {
        }

        /// <summary>
        /// Get the list of Bar series.
        /// </summary>
        public IList<BarSeries> BarSeries
        {
            get
            {
                return this.Find.AllByType<BarSeries>();
            }
        }

        /// <summary>
        /// Get the list of Line series.
        /// </summary>
        public IList<LineSeries> LineSeries
        {
            get
            {
                return this.Find.AllByType<LineSeries>();
            }
        }

        /// <summary>
        /// Get the list of ScatterPoint series.
        /// </summary>
        public IList<ScatterPointSeries> ScatterPointSeries
        {
            get
            {
                return this.Find.AllByType<ScatterPointSeries>();
            }
        }

        /// <summary>
        /// Get the CategoricalAxis.
        /// </summary>
        public CategoricalAxis CategoricalAxis
        {
            get
            {
                return this.Find.ByType<CategoricalAxis>();
            }
        }

        /// <summary>
        /// Get the DateTimeContinuousAxis.
        /// </summary>
        public DateTimeContinuousAxis DateTimeContinuousAxis
        {
            get
            {
                return this.Find.ByType<DateTimeContinuousAxis>();
            }
        }

        /// <summary>
        /// Get the list of Linear axes.
        /// </summary>
        public IList<LinearAxis> LinearAxis
        {
            get
            {
                return this.Find.AllByType<LinearAxis>();
            }
        }

        /// <summary>
        /// Get the list of Logarithmic Axes.
        /// </summary>
        public IList<LogarithmicAxis> LogarithmicAxis
        {
            get
            {
                return this.Find.AllByType<LogarithmicAxis>();
            }
        }

        /// <summary>
        /// Get the list of Labels.
        /// </summary>
        public IList<IList<ChartViewSeriesItemLabel>> SeriesItemLabels
        {
            get
            {
                Canvas labelCanvas = this.Find.ByName<Canvas>("labelContainer");
                return (from p in labelCanvas.Children
                        where p.Name != "renderSurface"
                        select (from label in p.Children
                                select new ChartViewSeriesItemLabel(label.As<TextBlock>())).ToArray() as IList<ChartViewSeriesItemLabel>).ToList();
            }
        }

        /// <summary>
        /// Get the labels count.
        /// </summary>
        public int LabelsCount
        {
            get
            {
                return this.SeriesItemLabels[0].Count;
            }
        }

        /// <summary>
        /// Get the xaml tag of RadCartesianChart.
        /// </summary>
        public override string XamlTag
        {
            get
            {
                return MappingKeys.RadCartesianChartKey;
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
