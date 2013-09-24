using System.Collections.Generic;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

namespace Wrappers.ChartView
{
    /// <summary>
    /// Represents the ShapePoint class
    /// </summary>
    public class ShapePoint<T> : ContentControl
        where T : Shape
    {
        /// <summary>
        /// Represents the ShapePoint class
        /// </summary>
        public ShapePoint(T shape)
        {
            this.Shape = shape;
        }

        /// <summary>
        /// Get and Set the Shape
        /// </summary>
        public T Shape
        {
            get;
            private set;
        }

        /// <summary>
        /// Get the Shape width
        /// </summary>
        public double Width
        {
            get
            {
                return this.Shape.Width;
            }
        }

        /// <summary>
        /// Get the Shape height
        /// </summary>
        public double Height
        {
            get
            {
                return this.Shape.Height;
            }
        }

        /// <summary>
        /// Get the Shape fill
        /// </summary>
        public Color FillColor
        {
            get
            {
                SolidColorBrush brush = this.Shape.Fill as SolidColorBrush;
                return brush == null ? null : brush.Color;
            }
        }

        /// <summary>
        /// Get the selected color RGB representation. Example: '255:0:0'.
        /// </summary>
        public string FillColorValue
        {
            get
            {
                return Helper.GetColorRGBPatternValue(this.FillColor);
            }
        }

        /// <summary>
        /// Get the Shape stroke
        /// </summary>
        public Color StrokeColor
        {
            get
            {
                SolidColorBrush brush = this.Shape.Stroke as SolidColorBrush;
                return brush == null ? null : brush.Color;
            }
        }

        /// <summary>
        /// Get the selected color RGB representation. Example: '255:0:0'.
        /// </summary>
        public string StrokeColorValue
        {
            get
            {
                return Helper.GetColorRGBPatternValue(this.StrokeColor);
            }
        }

        /// <summary>
        /// Get the shape CanvasLeft
        /// </summary>
        public double CanvasLeft
        {
            get
            {
                return this.Shape.GetAttachedProperty<double>("System.Windows.Controls.Canvas", "Left");
            }
        }

        /// <summary>
        /// Get the shape CanvasTop
        /// </summary>
        public double CanvasTop
        {
            get
            {
                return this.Shape.GetAttachedProperty<double>("System.Windows.Controls.Canvas", "Top");
            }
        }

        /// <summary>
        /// Get the Shape visibility
        /// </summary>
        public Visibility Visibility
        {
            get
            {
                return this.Shape.Visibility;
            }
        }
    }
}

