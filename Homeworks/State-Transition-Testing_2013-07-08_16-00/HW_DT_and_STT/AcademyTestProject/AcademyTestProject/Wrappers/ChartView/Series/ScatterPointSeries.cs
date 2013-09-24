using System.Collections.Generic;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;
using System.Linq;

namespace Wrappers.ChartView
{
    /// <summary>
    /// Represents the ScatterPointSeries for RadCartesianChart Silverlight control wrapper.
    /// </summary>
    public class ScatterPointSeries : ContentControl
    {
        /// <summary>
        /// Initializes a new instance of the ScatterPointSeries class.
        /// </summary>
        public ScatterPointSeries()
        {
        }

        /// <summary>
        /// Get the Scatter ZIndex
        /// </summary>
        public int ZIndex
        {
            get
            {
                return this.GetAttachedProperty<int>("System.Windows.Controls.Canvas", "ZIndex");
            }
        }

        /// <summary>
        /// Get the list of Path scatter points.
        /// </summary>
        public IList<ShapePoint<Path>> PathScatterPoints
        {
            get
            {
                return (from path in this.Find.AllByType<Path>()
                        select new ShapePoint<Path>(path)).ToList();
            }
        }

        /// <summary>
        /// Get the list of Ellipse scatter points.
        /// </summary>
        public IList<ShapePoint<Ellipse>> EllipseScatterPoints
        {
            get
            {
                return (from ellipse in this.Find.AllByType<Ellipse>()
                        select new ShapePoint<Ellipse>(ellipse)).ToList();
            }
        }

        /// <summary>
        /// Get the list of Rectangle scatter points.
        /// </summary>
        public IList<ShapePoint<Rectangle>> RectangleScatterPoints
        {
            get
            {
                return (from rectangle in this.Find.AllByType<Rectangle>()
                        select new ShapePoint<Rectangle>(rectangle)).ToList();
            }
        }

        /// <summary>
        /// Get the list of Triangle scatter points.
        /// </summary>
        public IList<ShapePoint<Polygon>> TriangleScatterPoints
        {
            get
            {
                return (from triangle in this.Find.AllByType<Polygon>()
                        select new ShapePoint<Polygon>(triangle)).ToList();
            }
        }

        /// <summary>
        /// Get the path scatter points count.
        /// </summary>
        public int PathScatterPointsCount
        {
            get
            {
                return this.PathScatterPoints.Count - 1;
            }
        }

        /// <summary>
        /// Get the ellipse scatter points count.
        /// </summary>
        public int EllipseScatterPointsCount
        {
            get
            {
                return this.EllipseScatterPoints.Count-1;
            }
        }

        /// <summary>
        /// Get the rectangle scatter points count.
        /// </summary>
        public int RectangleScatterPointsCount
        {
            get
            {
                return this.RectangleScatterPoints.Count - 1;
            }
        }

        /// <summary>
        /// Get the triangle scatter points count.
        /// </summary>
        public int TriangleScatterPointsCount
        {
            get
            {
                return this.TriangleScatterPoints.Count - 1;
            }
        }

        /// <summary>
        /// Get the xaml tag of ScatterPointSeries.
        /// </summary>
        public override string XamlTag
        {
            get
            {
                return MappingKeys.ScatterPointSeriesKey;
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

