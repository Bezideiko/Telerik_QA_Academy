using System.Collections.Generic;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;
using System.Linq;

namespace Wrappers.ChartView
{
    /// <summary>
    /// Represents the ChartViewContentPresenter class
    /// </summary>
    public class ChartViewContentPresenter : Control
    {
        /// <summary>
        /// Represents the ChartViewContentPresenter class
        /// </summary>
        public ChartViewContentPresenter(ContentPresenter contentpresenter)
        {
            this.ContentPresenter = contentpresenter;
        }

        /// <summary>
        /// Get and Set the content presenter
        /// </summary>
        public ContentPresenter ContentPresenter { get; private set; }

        /// <summary>
        /// Get the ChartViewContentPresenter CanvasLeft
        /// </summary>
        public double CanvasLeft
        {
            get
            {
                return this.ContentPresenter.GetAttachedProperty<double>("System.Windows.Controls.Canvas", "Left");
            }
        }

        /// <summary>
        /// Get the ChartViewContentPresenter CanvasTop
        /// </summary>
        public double CanvasTop
        {
            get
            {
                return this.ContentPresenter.GetAttachedProperty<double>("System.Windows.Controls.Canvas", "Top");
            }
        }

        /// <summary>
        /// Get the list of Labels.
        /// </summary>
        public IList<ChartViewAxisLabel> Labels
        {
            get
            {
                return (from label in this.ContentPresenter.Find.AllByType<TextBlock>()
                        select new ChartViewAxisLabel(label)).ToList();
            }
        }

        /// <summary>
        /// Get the ContentPresenter visibility
        /// </summary>
        public Visibility Visibility
        {
            get
            {
                return this.Visibility;
            }
        }

        /// <summary>
        /// Get the ContentPresenter height
        /// </summary>
        public double ContentPresenterHeight
        {
            get
            {
                return this.ActualHeight;
            }
        }

        /// <summary>
        /// Get the ContentPresenter width
        /// </summary>
        public double ContentPresenterWidth
        {
            get
            {
                return this.ActualWidth;
            }
        }
    }
}

