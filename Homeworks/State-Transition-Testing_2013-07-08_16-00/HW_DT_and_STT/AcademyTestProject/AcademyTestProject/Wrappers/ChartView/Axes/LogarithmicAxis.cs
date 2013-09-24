using System.Collections.Generic;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;
using System.Linq;

namespace Wrappers.ChartView
{
    /// <summary>
    /// Represents the LogarithmicAxis for RadCartesianChart Silverlight control wrapper.
    /// </summary>
    public class LogarithmicAxis : Control
    {
        private double _X1Value, _X2Value, _Y1Value, _Y2Value;
        private double axisLineStrokeThickness;
        private Color axisLineColor;

        /// <summary>
        /// Initializes a new instance of the LogarithmicAxis class.
        /// </summary>
        public LogarithmicAxis()
        {
        }

        /// <summary>
        /// Get the X1 value.
        /// </summary>
        public double X1Value
        {
            get
            {
                return this._X1Value;
            }
        }

        /// <summary>
        /// Get the X2 value.
        /// </summary>
        public double X2Value
        {
            get
            {
                return this._X2Value;
            }
        }

        /// <summary>
        /// Get the Y1 value.
        /// </summary>
        public double Y1Value
        {
            get
            {
                return this._Y1Value;
            }
        }

        /// <summary>
        /// Get the Y2 value.
        /// </summary>
        public double Y2Value
        {
            get
            {
                return this._Y2Value;
            }
        }

        /// <summary>
        /// Get the axis line color.
        /// </summary>
        public Color AxisLineColor
        {
            get
            {
                return this.axisLineColor;
            }
        }

        /// <summary>
        /// Get the selected color RGB representation. Example: '255:0:0'.
        /// </summary>
        public string AxisLineColorValue
        {
            get
            {
                return Helper.GetColorRGBPatternValue(this.AxisLineColor);
            }
        }

        /// <summary>
        /// Get the axisLine StrokeThickness.
        /// </summary>
        public double AxisLineStrokeThickness
        {
            get
            {
                return this.axisLineStrokeThickness;
            }
        }

        /// <summary>
        /// Get the list of Labels.
        /// </summary>
        public IList<ChartViewAxisLabel> Labels
        {
            get
            {
                return (from label in this.Find.AllByType<TextBlock>()
                        select new ChartViewAxisLabel(label)).ToList();
            }
        }

        /// <summary>
        /// Get the list of all visible Labels.
        /// </summary>
        public IList<ChartViewAxisLabel> VisibleLabels
        {
            get
            {
                return (from label in this.Find.AllByType<TextBlock>()
                        where label.Visibility.ToString().EndsWith("Visible")
                        select new ChartViewAxisLabel(label)).ToList();
            }
        }

        /// <summary>
        /// Get the labels count.
        /// </summary>
        public int LabelsCount
        {
            get
            {
                return this.Labels.Count - 1;
            }
        }

        /// <summary>
        /// Get the visible labels count.
        /// </summary>
        public int VisibleLabelsCount
        {
            get
            {
                return this.VisibleLabels.Count - 1;
            }
        }

        /// <summary>
        /// Get the list of Ticks.
        /// </summary>
        public IList<ChartViewAxisTick> Ticks
        {
            get
            {
                return (from tick in this.Find.AllByType<Rectangle>()
                        select new ChartViewAxisTick(tick)).ToList();
            }
        }

        /// <summary>
        /// Get the list of visible Ticks.
        /// </summary>
        public IList<ChartViewAxisTick> VisibleTicks
        {
            get
            {
                return (from tick in this.Find.AllByType<Rectangle>()
                        where tick.Visibility.ToString().EndsWith("Visible")
                        select new ChartViewAxisTick(tick)).ToList();
            }
        }

        /// <summary>
        /// Get the ticks count.
        /// </summary>
        public int TicksCount
        {
            get
            {
                return this.Ticks.Count;
            }
        }

        /// <summary>
        /// Get the visible ticks count.
        /// </summary>
        public int VisibleTicksCount
        {
            get
            {
                return this.VisibleTicks.Count;
            }
        }

        /// <summary>
        /// Get the title presenter.
        /// </summary>
        public ChartViewContentPresenter TitlePresenter
        {
            get
            {
                return new ChartViewContentPresenter(this.Find.ByType<ContentPresenter>());
            }
        }

        /// <summary>
        /// Get the xaml tag of LogarithmicAxis.
        /// </summary>
        public override string XamlTag
        {
            get
            {
                return MappingKeys.LogarithmicAxisKey;
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

            // get the axis line
            Line axisLine = this.Find.ByType<Line>();

            // get the axis line X1, X2, Y1 and Y2 values
            this._X1Value = axisLine.X1;
            this._X2Value = axisLine.X2;
            this._Y1Value = axisLine.Y1;
            this._Y2Value = axisLine.Y2;

            // get the axis line StrokeThickness
            this.axisLineStrokeThickness = axisLine.StrokeThickness;

            // get the axis line color
            SolidColorBrush brush2 = axisLine.Stroke as SolidColorBrush;
            this.axisLineColor = brush2 == null ? null : brush2.Color;
        }
    }
}

