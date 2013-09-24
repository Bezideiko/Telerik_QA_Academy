using System;
using System.Collections.Generic;
using ArtOfTest.WebAii.Silverlight.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrappers.ChartView; 

namespace Tests
{
    [TestClass]
    public class Tests : ChartViewBase
    {
        [ClassCleanup()]
        public static void MenuTestClassCleanup()
        {
            LocalBase.MyClassCleanup();
        }

        [TestMethod]
        [Description("Check ChartView scenario with Linear and Linear axes combination")]
        public void VerticalLinearHorizontalLinearAxesTest()
        {
            LaunchInitialize("/ExamplesTestPage.aspx#ChartViewAxesExample");

            //Click "Linear/Linear" button
            app.Find.ByName<Button>("btnLinearLinear").User.Click();

            // Locating the chart
            this._cartesianchart = app.Find.ByName("RadChart1").As<RadCartesianChart>();
            app.RefreshVisualTrees();
            this._cartesianchart.Refresh();

            //Initialize axes
            LinearAxis axisY = this._cartesianchart.LinearAxis[0];
            LinearAxis axisX = this._cartesianchart.LinearAxis[1];

            //Check AxisX X1, X2, Y1, Y2 coordinates
            CheckHorizontalLinearAxisCoordinates(axisX, 44, 983, 604, 604, tolerance);

            //Check AxisY X1, X2, Y1, Y2 coordinates
            CheckVerticalLinearAxisCoordinates(axisY, 44, 44, 12, 604, tolerance);

            // Check the AxisX item labels count
            Assert.AreEqual<int>(9, axisX.LabelsCount, "Verification of series item label count failed!");

            // Check the AxisY item labels count
            Assert.AreEqual<int>(6, axisY.LabelsCount, "Verification of series item label count failed!");

            // Check the AxisX item labels text
            string[] axisXLabels = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            for (int i = 0; i < axisXLabels.Length; i++)
            {
                Assert.AreEqual<string>(axisXLabels[i], axisX.Labels[i + 1].LabelText, "Verification of series item labels failed!");
            }

            // Check the AxisY item labels text
            string[] axisYLabels = new string[] { "0", "5", "10", "15", "20", "25" };
            for (int i = 0; i < axisYLabels.Length; i++)
            {
                Assert.AreEqual<string>(axisYLabels[i], axisY.Labels[i + 1].LabelText, "Verification of series item labels failed!");
            }

            //Check AxisX title
            Assert.AreEqual<string>("Horizontal Linear Axis", axisX.Labels[0].LabelText);

            //Check AxisY title
            Assert.AreEqual<string>("Vertical Linear Axis", axisY.Labels[0].LabelText);

            //Initialize ScatterPointSeries
            ScatterPointSeries scatterSeries = _cartesianchart.ScatterPointSeries[0];
            
            //Verify the number of scatter points
            Assert.AreEqual(7, scatterSeries.EllipseScatterPointsCount, "ScatterPoints count verification failed!");

            //Verify scatter points size
            for (int i = 0; i < _cartesianchart.ScatterPointSeries[0].EllipseScatterPointsCount; i++)
            {
                Assert.AreEqual(11 ,scatterSeries.EllipseScatterPoints[i].Width, "ScatterPoint width verification failed!");
                Assert.AreEqual(11, scatterSeries.EllipseScatterPoints[i].Height, "ScatterPoint height verification failed!");
            }
        }

        [TestMethod]
        [Description("Check ChartView scenario when chart is loaded for the first time")]
        public void ChartViewFirstTimeLoadTest()
        {
            LaunchInitialize("/ExamplesTestPage.aspx#Zooming");

            //Click "Load" button
            app.Find.ByName<Button>("btnLoadChart").User.Click();

            // Locating the chart
            this._cartesianchart = app.Find.ByName("RadChart1").As<RadCartesianChart>();
            app.RefreshVisualTrees();
            this._cartesianchart.Refresh();

            //Initialize axes
            LinearAxis axisY = this._cartesianchart.LinearAxis[0];
            CategoricalAxis axisX = this._cartesianchart.CategoricalAxis;

            // Check the AxisX item labels count
            Assert.AreEqual<int>(15, axisX.LabelsCount, "Verification of series item label count failed!");

            // Verify X axis labels text
            for (int i = 0; i < 15; i++)
            {
                Assert.AreEqual<string>("Label " + i, axisX.Labels[i + 1].LabelText, "Verification of series item labels failed!");
            }

            //Click "Print" button
            app.Find.ByName<Button>("btnPrint").User.Click();
            this.app.RefreshVisualTrees();
            
            //Verify chart is being printed
            StackPanel panel = this.app.Find.ByName<StackPanel>("Panel");

            TextBlock textBlock = this.app.Find.ByName<TextBlock>("Textblock");
            Assert.AreEqual("Chart has been sent for printing...", textBlock.Text);
            panel.Find.ByType<Button>().User.Click();
        }

        [TestMethod]
        [Description("Check ChartView scenario when applying zoom and printing")]
        public void ChartViewZoomInAndPrintTest()
        {
            LaunchInitialize("/ExamplesTestPage.aspx#Zooming");

            //Click "Load" button
            app.Find.ByName<Button>("btnLoadChart").User.Click();

            // Locating the chart
            this._cartesianchart = app.Find.ByName("RadChart1").As<RadCartesianChart>();

            //Click "ApplyZoom" button
            app.Find.ByName<Button>("btnApplyZoom").User.Click();
            app.RefreshVisualTrees();
            this._cartesianchart.Refresh();

            // Zoom In
            var panZoomBarStartThumb = app.Find.AllByName<Thumb>("RangeStartThumb");
            panZoomBarStartThumb[0].User.DragTo(60, 0);
            this.app.RefreshVisualTrees();

            // Verify the number of visible bars
            BarSeries barSeries = this._cartesianchart.BarSeries[0];
            Assert.AreEqual(7, barSeries.VisibleBarsCount);

            //Click "Print" button
            app.Find.ByName<Button>("btnPrint").User.Click();
            this.app.RefreshVisualTrees();

            //Verify chart is being printed
            StackPanel panel = this.app.Find.ByName<StackPanel>("Panel");

            TextBlock textBlock = this.app.Find.ByName<TextBlock>("Textblock");
            Assert.AreEqual("Chart has been sent for printing...", textBlock.Text);
            panel.Find.ByType<Button>().User.Click();
        }

        [TestMethod]
        [Description("Check ChartView scenario with Linear and DateTimeContinuous axes combination")]
        public void VerticalDateTimeContinuousHorizontalLinearAxesTest()
        {
            LaunchInitialize("/ExamplesTestPage.aspx#ChartViewAxesExample");

            //Click "Linear/DateTimeContinuous" button
            app.Find.ByName<Button>("btnDateTimeContinuousLinear").User.Click();

            // Locating the chart
            this._cartesianchart = app.Find.ByName("RadChart1").As<RadCartesianChart>();
            app.RefreshVisualTrees();
            this._cartesianchart.Refresh();

            //Initialize axes
            DateTimeContinuousAxis axisY = this._cartesianchart.DateTimeContinuousAxis;
            LinearAxis axisX = this._cartesianchart.LinearAxis[0];

            //Check AxisX X1, X2, Y1, Y2 coordinates
            CheckHorizontalLinearAxisCoordinates(axisX, 95, 979, 604, 604, tolerance);

            //Check AxisY X1, X2, Y1, Y2 coordinates
            CheckVerticalDateTimeContinuousAxisCoordinates(axisY, 95, 95, 12, 604, tolerance);

            // Check the AxisX item labels count
            Assert.AreEqual<int>(7, axisX.LabelsCount, "Verification of series item label count failed!");

            // Check the AxisY item labels count
            Assert.AreEqual<int>(7, axisY.LabelsCount, "Verification of series item label count failed!");

            // Check the AxisX item labels text
            string[] axisXLabels = new string[] { "0", "10", "20", "30", "40", "50", "60" };
            for (int i = 0; i < axisXLabels.Length; i++)
            {
                Assert.AreEqual<string>(axisXLabels[i], axisX.Labels[i + 1].LabelText, "Verification of series item labels failed!");
            }

            // Check the AxisY item labels text
            string[] axisYLabels = new string[] { "Jul 05 2013", "Jul 06 2013", "Jul 07 2013", "Jul 08 2013", "Jul 09 2013", "Jul 10 2013", "Jul 11 2013" };
            for (int i = 0; i < axisYLabels.Length; i++)
            {
                Assert.AreEqual<string>(axisYLabels[i], axisY.Labels[i + 1].LabelText, "Verification of series item labels failed!");
            }

            //Check AxisX title
            Assert.AreEqual<string>("Horizontal Linear Axis", axisX.Labels[0].LabelText);

            //Check AxisY title
            Assert.AreEqual<string>("Vertical DateTimeContinuous Axis", axisY.Labels[0].LabelText);

            //Initialize LineSeries
            LineSeries lineSeries = _cartesianchart.LineSeries[0];

            //Verify the number of scatter points
            Assert.AreEqual(100, lineSeries.ZIndex, "LineSeries ZIndex verification failed!");
        }
    }
}
