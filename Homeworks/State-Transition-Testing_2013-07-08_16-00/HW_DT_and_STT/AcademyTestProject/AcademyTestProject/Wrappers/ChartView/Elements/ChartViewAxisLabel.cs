using System.Collections.Generic;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

namespace Wrappers.ChartView
{
    /// <summary>
    /// Represents the ChartViewAxisLabel class
    /// </summary>
    public class ChartViewAxisLabel : Control
    {
        /// <summary>
        /// Represents the ChartViewAxisLabel class
        /// </summary>
        public ChartViewAxisLabel(TextBlock label)
        {
            this.Label = label;
        }

        /// <summary>
        /// Get and Set the label
        /// </summary>
        public TextBlock Label { get; private set; }

        /// <summary>
        /// Get the label text
        /// </summary>
        public string LabelText
        {
            get
            {
                return this.Label.Text;
            }
        }

        /// <summary>
        /// Get the label angle
        /// </summary>
        public double LabelAngle
        {
            get
            {
                return (this.Label.RenderTransform as RotateTransform).Angle;
            }
        }

        /// <summary>
        /// Get the label font size
        /// </summary>
        public double LabelFontSize
        {
            get
            {
                return this.Label.FontSize;
            }
        }

        /// <summary>
        /// Get the label color
        /// </summary>
        public Color LabelColor
        {
            get
            {
                SolidColorBrush brush = this.Label.Foreground as SolidColorBrush;
                return brush == null ? null : brush.Color;
            }
        }

        /// <summary>
        /// Get the label CanvasLeft
        /// </summary>
        public double CanvasLeft
        {
            get
            {
                return this.Label.GetAttachedProperty<double>("System.Windows.Controls.Canvas", "Left");
            }
        }

        /// <summary>
        /// Get the label CanvasTop
        /// </summary>
        public double CanvasTop
        {
            get
            {
                return this.Label.GetAttachedProperty<double>("System.Windows.Controls.Canvas", "Top");
            }
        }

        /// <summary>
        /// Get the ChartViewBarItem visibility
        /// </summary>
        public Visibility Visibility
        {
            get
            {
                return this.Label.Visibility;
            }
        }
    }
}

