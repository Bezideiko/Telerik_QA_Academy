using System.Collections.Generic;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

namespace Wrappers.ChartView
{
    /// <summary>
    /// Represents the ChartViewAxisTick class
    /// </summary>
    public class ChartViewAxisTick
    {
        /// <summary>
        /// Represents the ChartViewAxisTick class
        /// </summary>
        public ChartViewAxisTick(Rectangle tick)
        {
            this.Tick = tick;
        }

        /// <summary>
        /// Get and Set the tick
        /// </summary>
        public Rectangle Tick { get; private set; }

        /// <summary>
        /// Get the tick height
        /// </summary>
        public double TickHeight
        {
            get
            {
                return this.Tick.Height;
            }
        }

        /// <summary>
        /// Get the tick width
        /// </summary>
        public double TickWidth
        {
            get
            {
                return this.Tick.Width;
            }
        }

        /// <summary>
        /// Get the tick CanvasLeft
        /// </summary>
        public double CanvasLeft
        {
            get
            {
                return this.Tick.GetAttachedProperty<double>("System.Windows.Controls.Canvas", "Left");
            }
        }

        /// <summary>
        /// Get the tick CanvasTop
        /// </summary>
        public double CanvasTop
        {
            get
            {
                return this.Tick.GetAttachedProperty<double>("System.Windows.Controls.Canvas", "Top");
            }
        }

        /// <summary>
        /// Get the tick stroke thickness
        /// </summary>
        public double TickStrokeThickness
        {
            get
            {
                return this.Tick.StrokeThickness;
            }
        }

        /// <summary>
        /// Get the tick color
        /// </summary>
        public Color TickColor
        {
            get
            {
                SolidColorBrush brush = this.Tick.Fill as SolidColorBrush;
                return brush == null ? null : brush.Color;
            }
        }
    }
}
