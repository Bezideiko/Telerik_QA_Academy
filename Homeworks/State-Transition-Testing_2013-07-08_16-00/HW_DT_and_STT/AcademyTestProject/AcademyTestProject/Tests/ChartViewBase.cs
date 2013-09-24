using System.Collections.Generic;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;
using ArtOfTest.WebAii.TestTemplates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrappers;
using System;
using Wrappers.ChartView;

namespace Tests
{
    [TestClass]
    public class ChartViewBase : LocalBase
    {
        public ChartViewBase()
        {

        }

        public const int tolerance = 3;

        protected RadCartesianChart _cartesianchart;

        protected override void ConfigureSettings(Settings settings)
        {
            base.ConfigureSettings(settings);
            settings.ExecutionDelay = 80;
        }

        protected override SilverlightApp LaunchInitialize(string demoPath)
        {
            if (Manager.Browsers.Count != 0 &&
                ActiveBrowser.Url.EndsWith(demoPath, System.StringComparison.OrdinalIgnoreCase))
            {
                this.ActiveBrowser.Refresh();
                this.ActiveBrowser.WaitUntilReady();
            }

            base.LaunchInitialize(demoPath);
            return this.app;
        }

        /// <summary>
        /// Checks the color in RGB.
        /// </summary>
        public void CheckColor(Color color, byte rValue, byte gValue, byte bValue)
        {
            Assert.AreEqual<byte>(rValue, color.R, "'R' color value verification failed!");
            Assert.AreEqual<byte>(gValue, color.G, "'G' color value verification failed!");
            Assert.AreEqual<byte>(bValue, color.B, "'B' color value verification failed!");
        }

        /// <summary>
        /// Checks the color in ARGB.
        /// </summary>
        public void CheckColor(Color color, byte aValue, byte rValue, byte gValue, byte bValue)
        {
            Assert.AreEqual<byte>(aValue, color.A, "'A' color value verification failed!");
            Assert.AreEqual<byte>(rValue, color.R, "'R' color value verification failed!");
            Assert.AreEqual<byte>(gValue, color.G, "'G' color value verification failed!");
            Assert.AreEqual<byte>(bValue, color.B, "'B' color value verification failed!");
        }

        /// <summary>
        /// Checks bar item values.
        /// </summary>
        public void CheckBarValues(ChartViewBarItem bar, double height, double width, double tolerance)
        {
            Assert.AreEqual(width, bar.Width, tolerance, "Bar width verification failed!");
            Assert.AreEqual(height, bar.Height, tolerance, "Bar height verification failed!");
        }

        /// <summary>
        /// Checks bar item canvas left and top values.
        /// </summary>
        public void CheckBarItemCanvasLeftTopValues(ChartViewBarItem bar, double canvastLeft, double canvasTop, double tolerance)
        {
            Assert.AreEqual(canvastLeft, bar.CanvasLeft, tolerance, "Bar canvas left verification failed!");
            Assert.AreEqual(canvasTop, bar.CanvasTop, tolerance, "Bar canvas top verification failed!");
        }

        /// <summary>
        /// Checks vertical Linear axis coordinates values
        /// </summary>
        public void CheckVerticalLinearAxisCoordinates(LinearAxis axis, double X1, double X2, double Y1, double Y2, double tolerance)
        {
            Assert.AreEqual(X1, axis.X1Value, tolerance, "Coordinates X1Value verification failed!");
            Assert.AreEqual(X2, axis.X2Value, tolerance, "Coordinates X2Value verification failed!");
            Assert.AreEqual(Y1, axis.Y1Value, tolerance, "Coordinates Y1Value verification failed!");
            Assert.AreEqual(Y2, axis.Y2Value, tolerance, "Coordinates Y2Value verification failed!");
            Assert.IsTrue(axis.X1Value == axis.X2Value, "Axis X1, X2 coordinates are not equal!");
        }

        /// <summary>
        /// Checks horizontal Linear axis coordinates values
        /// </summary>
        public void CheckHorizontalLinearAxisCoordinates(LinearAxis axis, double X1, double X2, double Y1, double Y2, double tolerance)
        {
            Assert.AreEqual(X1, axis.X1Value, tolerance, "Coordinates X1Value verification failed!");
            Assert.AreEqual(X2, axis.X2Value, tolerance, "Coordinates X2Value verification failed!");
            Assert.AreEqual(Y1, axis.Y1Value, tolerance, "Coordinates Y1Value verification failed!");
            Assert.AreEqual(Y2, axis.Y2Value, tolerance, "Coordinates Y2Value verification failed!");
            Assert.IsTrue(axis.Y1Value == axis.Y2Value, "Axis Y1, Y2 coordinates are not equal!");
        }

        /// <summary>
        /// Checks vertical Categorical axis coordinates values
        /// </summary>
        public void CheckVerticalCategoricalAxisCoordinates(CategoricalAxis axis, double X1, double X2, double Y1, double Y2, double tolerance)
        {
            Assert.AreEqual(X1, axis.X1Value, tolerance, "Coordinates X1Value verification failed!");
            Assert.AreEqual(X2, axis.X2Value, tolerance, "Coordinates X2Value verification failed!");
            Assert.AreEqual(Y1, axis.Y1Value, tolerance, "Coordinates Y1Value verification failed!");
            Assert.AreEqual(Y2, axis.Y2Value, tolerance, "Coordinates Y2Value verification failed!");
            Assert.IsTrue(axis.X1Value == axis.X2Value, "Axis X1, X2 coordinates are not equal!");
        }

        /// <summary>
        /// Checks horizontal Categorical axis coordinates values
        /// </summary>
        public void CheckHorizontalCategoricalAxisCoordinates(CategoricalAxis axis, double X1, double X2, double Y1, double Y2, double tolerance)
        {
            Assert.AreEqual(X1, axis.X1Value, tolerance, "Coordinates X1Value verification failed!");
            Assert.AreEqual(X2, axis.X2Value, tolerance, "Coordinates X2Value verification failed!");
            Assert.AreEqual(Y1, axis.Y1Value, tolerance, "Coordinates Y1Value verification failed!");
            Assert.AreEqual(Y2, axis.Y2Value, tolerance, "Coordinates Y2Value verification failed!");
            Assert.IsTrue(axis.Y1Value == axis.Y2Value, "Axis Y1, Y2 coordinates are not equal!");
        }

        /// <summary>
        /// Checks vertical Logarithmic axis coordinates values
        /// </summary>
        public void CheckVerticalLogarithmicAxisCoordinates(LogarithmicAxis axis, double X1, double X2, double Y1, double Y2, double tolerance)
        {
            Assert.AreEqual(X1, axis.X1Value, tolerance, "Coordinates X1Value verification failed!");
            Assert.AreEqual(X2, axis.X2Value, tolerance, "Coordinates X2Value verification failed!");
            Assert.AreEqual(Y1, axis.Y1Value, tolerance, "Coordinates Y1Value verification failed!");
            Assert.AreEqual(Y2, axis.Y2Value, tolerance, "Coordinates Y2Value verification failed!");
            Assert.IsTrue(axis.X1Value == axis.X2Value, "Axis X1, X2 coordinates are not equal!");
        }

        /// <summary>
        /// Checks horizontal Logarithmic axis coordinates values
        /// </summary>
        public void CheckHorizontalLogarithmicAxisCoordinates(LogarithmicAxis axis, double X1, double X2, double Y1, double Y2, double tolerance)
        {
            Assert.AreEqual(X1, axis.X1Value, tolerance, "Coordinates X1Value verification failed!");
            Assert.AreEqual(X2, axis.X2Value, tolerance, "Coordinates X2Value verification failed!");
            Assert.AreEqual(Y1, axis.Y1Value, tolerance, "Coordinates Y1Value verification failed!");
            Assert.AreEqual(Y2, axis.Y2Value, tolerance, "Coordinates Y2Value verification failed!");
            Assert.IsTrue(axis.Y1Value == axis.Y2Value, "Axis Y1, Y2 coordinates are not equal!");
        }

        /// <summary>
        /// Checks vertical DateTimeContinuous axis coordinates values
        /// </summary>
        public void CheckVerticalDateTimeContinuousAxisCoordinates(DateTimeContinuousAxis axis, double X1, double X2, double Y1, double Y2, double tolerance)
        {
            Assert.AreEqual(X1, axis.X1Value, tolerance, "Coordinates X1Value verification failed!");
            Assert.AreEqual(X2, axis.X2Value, tolerance, "Coordinates X2Value verification failed!");
            Assert.AreEqual(Y1, axis.Y1Value, tolerance, "Coordinates Y1Value verification failed!");
            Assert.AreEqual(Y2, axis.Y2Value, tolerance, "Coordinates Y2Value verification failed!");
            Assert.IsTrue(axis.X1Value == axis.X2Value, "Axis X1, X2 coordinates are not equal!");
        }

        /// <summary>
        /// Checks horizontal DateTimeContinuous axis coordinates values
        /// </summary>
        public void CheckHorizontalDateTimeContinuousAxisCoordinates(DateTimeContinuousAxis axis, double X1, double X2, double Y1, double Y2, double tolerance)
        {
            Assert.AreEqual(X1, axis.X1Value, tolerance, "Coordinates X1Value verification failed!");
            Assert.AreEqual(X2, axis.X2Value, tolerance, "Coordinates X2Value verification failed!");
            Assert.AreEqual(Y1, axis.Y1Value, tolerance, "Coordinates Y1Value verification failed!");
            Assert.AreEqual(Y2, axis.Y2Value, tolerance, "Coordinates Y2Value verification failed!");
            Assert.IsTrue(axis.Y1Value == axis.Y2Value, "Axis Y1, Y2 coordinates are not equal!");
        }

        /// <summary>
        /// Checks ChartViewSeriesItemLabel position
        /// </summary>
        public void CheckChartViewSeriesItemLabelPosition(ChartViewSeriesItemLabel seriesItemLabel, double CanvasLeft, double CanvasTop)
        {
            Assert.AreEqual(CanvasLeft, seriesItemLabel.CanvasLeft, 2, "SeriesItemLabel CanvasLeft verification failed!");
            Assert.AreEqual(CanvasTop, seriesItemLabel.CanvasTop, 2, "SeriesItemLabel CanvasTop verification failed!");
        }
    }
}
