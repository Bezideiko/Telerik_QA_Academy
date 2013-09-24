using System.Collections.Generic;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

namespace Wrappers.ChartView
{
    /// <summary>
    /// Represents the ChartViewBarItem class
    /// </summary>
    public class ChartViewBarItem : ContentControl
    {
        /// <summary>
        /// Represents the ChartViewBarItem class
        /// </summary>
        public ChartViewBarItem(Border border)
        {
            this.Border = border;
        }                    

        /// <summary>
        /// Get and Set the Border
        /// </summary>
        public Border Border { get; private set; }

        /// <summary>
        /// Get the ChartViewBarItem width
        /// </summary>
        public double Width
        {
            get
            {
                return this.Border.Width;
            }
        }

        /// <summary>
        /// Get the ChartViewBarItem visibility
        /// </summary>
        public Visibility Visibility
        {
            get
            {
                return this.Border.Visibility;
            }
        }

        /// <summary>
        /// Get the ChartViewBarItem height
        /// </summary>
        public double Height
        {
            get
            {
                return this.Border.Height;
            }
        }

        /// <summary>
        /// Get the ChartViewBarItem CanvasLeft
        /// </summary>
        public double CanvasLeft
        {
            get
            {
                return this.Border.GetAttachedProperty<double>("System.Windows.Controls.Canvas", "Left");
            }
        }

        /// <summary>
        /// Get the ChartViewBarItem CanvasTop
        /// </summary>
        public double CanvasTop
        {
            get
            {
                return this.Border.GetAttachedProperty<double>("System.Windows.Controls.Canvas", "Top");
            }
        }

        /// <summary>
        /// Get the ChartViewBarItem CanvasRight
        /// </summary>
        public double CanvasRight
        {
            get
            {
                return this.Border.GetAttachedProperty<double>("System.Windows.Controls.Canvas", "Right");
            }
        }

        /// <summary>
        /// Get the ChartViewBarItem CanvasBottom
        /// </summary>
        public double CanvasBottom
        {
            get
            {
                return this.Border.GetAttachedProperty<double>("System.Windows.Controls.Canvas", "Bottom");
            }
        }

        /// <summary>
        /// Get the ChartViewBarItem ZIndex
        /// </summary>
        public int ZIndex
        {
            get
            {
                return this.Border.GetAttachedProperty<int>("System.Windows.Controls.Canvas", "ZIndex");
            }
        }

        /// <summary>
        /// Get the ChartViewBarItem color
        /// </summary>
        public Color Color
        {
            get
            {
                SolidColorBrush brush = this.Border.Background as SolidColorBrush;
                return brush == null ? null : brush.Color;
            }
        }

        /// <summary>
        /// Get the selected color RGB representation. Example: '255:0:0'.
        /// </summary>
        public string BarColorValue
        {
            get
            {
                return Helper.GetColorRGBPatternValue(this.Color);
            }
        }
    }
}
