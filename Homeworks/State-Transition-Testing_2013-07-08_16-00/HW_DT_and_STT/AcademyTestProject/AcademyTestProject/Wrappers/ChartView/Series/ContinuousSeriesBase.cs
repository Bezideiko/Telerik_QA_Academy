using System.Collections.Generic;
using System.Linq;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

namespace Wrappers.ChartView
{
    public abstract class ContinuousSeriesBase : Control
    {
        private Color strokeColor;
        private List<Point> pointsCollection;
        private List<Point> secondFigurePointsCollection;
        private List<PathFigure> figures;

        /// <summary>
        /// Initializes a new instance of the ContinuousSeriesBase class.
        /// </summary>
        public ContinuousSeriesBase()
        {
        }

        /// <summary>
        /// Get the indicator color.
        /// </summary>
        public Color StrokeColor
        {
            get
            {
                SolidColorBrush brush = Paths[0].Stroke as SolidColorBrush;
                this.strokeColor = brush == null ? null : brush.Color;
                return this.strokeColor;
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
        /// Get the stroke thickness
        /// </summary>
        public double StrokeThickness
        {
            get
            {
                return this.Paths[0].StrokeThickness;
            }
        }

        /// <summary>
        /// Get the list of paths.
        /// </summary>
        /// <remarks>
        /// Will return 1 for all continuous series and 2 for area series.
        /// The first is stroke shape and the second is area shape.
        /// </remarks>
        public IList<Path> Paths
        {
            get
            {
                return this.Find.AllByType<Path>();
            }
        }

        /// <summary>
        /// Gets a list of Figures
        /// </summary>
        /// <remarks>
        /// Will return 1 in scenarios with no empty values.
        /// </remarks>
        public List<PathFigure> Figures
        {
            get
            {
                return (this.Paths[0].Data as PathGeometry).Figures;
            }
        }

        /// <summary>
        /// Get the Points collection.
        /// </summary>
        public List<Point> PointsCollection
        {
            get
            {
                if (this.pointsCollection == null)
                {
                    this.pointsCollection = this.GetPoints(this.Figures[0]).ToList();
                }
                return this.pointsCollection;
            }
        }

        /// <summary>
        /// Get the Points collection of the second figure.
        /// </summary>
        public List<Point> SecondFigurePointsCollection
        {
            get
            {
                if (this.secondFigurePointsCollection == null)
                {
                    this.secondFigurePointsCollection = this.GetPoints(this.Figures[1]).ToList();
                }
                return this.secondFigurePointsCollection;
            }
        }

        protected IEnumerable<Point> GetPoints(PathFigure figure)
        {
            yield return figure.StartPoint;

            foreach (PolyLineSegment segment in figure.Segments)
            {
                foreach (var point in segment.Points)
                {
                    yield return point;
                }
            }
        }
    }
}

