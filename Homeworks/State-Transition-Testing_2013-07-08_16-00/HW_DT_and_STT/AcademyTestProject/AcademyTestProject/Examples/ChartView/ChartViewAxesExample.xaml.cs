using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Data;

namespace Examples.ChartView
{
    public partial class ChartViewAxesExample : UserControl
    {
        ViewModel viewModel = new ViewModel();

        ObservableCollection<ChartData> data1 = new ObservableCollection<ChartData>();
        //BarSeries barSeries = new BarSeries() { ShowLabels = true };
        //LineSeries lineSeries = new LineSeries() { ShowLabels = true };
        public ChartViewAxesExample()
        {
            InitializeComponent();
            this.DataContext = viewModel;

            data1.Add(new ChartData("Text 1", 15, 90, 1, 4, new DateTime(2013, 7, 5, 10, 55, 05)));
            data1.Add(new ChartData("Text 2", 23, 120, 2, 7, new DateTime(2013, 7, 6, 11, 45, 07)));
            data1.Add(new ChartData("Text 3", 34, 160, 3, 15, new DateTime(2013, 7, 7, 12, 25, 10)));
            data1.Add(new ChartData("Text 4", 43, 180, 4, 11, new DateTime(2013, 7, 8, 15, 34, 32)));
            data1.Add(new ChartData("Text 5", 27, 100, 5, 17, new DateTime(2013, 7, 9, 17, 20, 35)));
            data1.Add(new ChartData("Text 6", 38, 120, 6, 14, new DateTime(2013, 7, 10, 19, 35, 30)));
            data1.Add(new ChartData("Text 7", 55, 110, 7, 21, new DateTime(2013, 7, 11, 23, 05, 17)));

            //RadChart1.HorizontalAxis = new CategoricalAxis() { Title = "Horizontal Categorical Axis" };
            //RadChart1.VerticalAxis = new LinearAxis() { Title = "Vertical Linear Axis" };

            //barSeries.ItemsSource = data1;
            //barSeries.ShowLabels = true;
            //barSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Title" };
            //barSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
            //RadChart1.Series.Add(barSeries);
            ////show axis types
            //UpdateAxisTypesInfo();
        }

        public void UpdateAxisTypesInfo()
        {
            if (RadChart1.Visibility == System.Windows.Visibility.Visible)
            {
                viewModel.VerticalAxisType = RadChart1.VerticalAxis.GetType().ToString();
                viewModel.HorizontalAxisType = RadChart1.HorizontalAxis.GetType().ToString();
                txtHor1.Visibility = System.Windows.Visibility.Visible;
                txtHor2.Visibility = System.Windows.Visibility.Visible;
                txtVer1.Visibility = System.Windows.Visibility.Visible;
                txtVer2.Visibility = System.Windows.Visibility.Visible;
            }

            //customize HorizontalType display string
            if (viewModel.HorizontalAxisType == "Telerik.Windows.Controls.ChartView.CategoricalAxis")
                viewModel.HorizontalAxisType = "CategoricalAxis";
            else if (viewModel.HorizontalAxisType == "Telerik.Windows.Controls.ChartView.LinearAxis")
                viewModel.HorizontalAxisType = "LinearAxis";
            else if (viewModel.HorizontalAxisType == "Telerik.Windows.Controls.ChartView.DateTimeCategoricalAxis")
                viewModel.HorizontalAxisType = "DateTimeCategoricalAxis";
            else if (viewModel.HorizontalAxisType == ("Telerik.Windows.Controls.ChartView.DateTimeContinuousAxis"))
                viewModel.HorizontalAxisType = "DateTimeContinuousAxis";
            else if (viewModel.HorizontalAxisType == "Telerik.Windows.Controls.ChartView.CategoricalRadial")
                viewModel.HorizontalAxisType = "CategoricalRadial";
            else if (viewModel.HorizontalAxisType == "Telerik.Windows.Controls.ChartView.LogarithmicAxis")
                viewModel.HorizontalAxisType = "LogarithmicAxis";
            else if (viewModel.HorizontalAxisType == "Telerik.Windows.Controls.ChartView.NumericalAxis")
                viewModel.HorizontalAxisType = "NumericalAxis";
            else if (viewModel.HorizontalAxisType == "Telerik.Windows.Controls.ChartView.NumericalRadialAxis")
                viewModel.HorizontalAxisType = "NumericalRadialAxis";
            else if (viewModel.HorizontalAxisType == "Telerik.Windows.Controls.ChartView.PolarAxis")
                viewModel.HorizontalAxisType = "PolarAxis";
            else if (viewModel.HorizontalAxisType == "Telerik.Windows.Controls.ChartView.RadialAxis")
                viewModel.HorizontalAxisType = "RadialAxis";

            //customize HorizontalType display string
            if (viewModel.VerticalAxisType == "Telerik.Windows.Controls.ChartView.CategoricalAxis")
                viewModel.VerticalAxisType = "CategoricalAxis";
            else if (viewModel.VerticalAxisType == "Telerik.Windows.Controls.ChartView.LinearAxis")
                viewModel.VerticalAxisType = "LinearAxis";
            else if (viewModel.VerticalAxisType == "Telerik.Windows.Controls.ChartView.DateTimeCategoricalAxis")
                viewModel.VerticalAxisType = "DateTimeCategoricalAxis";
            else if (viewModel.VerticalAxisType == ("Telerik.Windows.Controls.ChartView.DateTimeContinuousAxis"))
                viewModel.VerticalAxisType = "DateTimeContinuousAxis";
            else if (viewModel.VerticalAxisType == "Telerik.Windows.Controls.ChartView.CategoricalRadial")
                viewModel.VerticalAxisType = "CategoricalRadial";
            else if (viewModel.VerticalAxisType == "Telerik.Windows.Controls.ChartView.LogarithmicAxis")
                viewModel.VerticalAxisType = "LogarithmicAxis";
            else if (viewModel.VerticalAxisType == "Telerik.Windows.Controls.ChartView.NumericalAxis")
                viewModel.VerticalAxisType = "NumericalAxis";
            else if (viewModel.VerticalAxisType == "Telerik.Windows.Controls.ChartView.NumericalRadialAxis")
                viewModel.VerticalAxisType = "NumericalRadialAxis";
            else if (viewModel.VerticalAxisType == "Telerik.Windows.Controls.ChartView.PolarAxis")
                viewModel.VerticalAxisType = "PolarAxis";
            else if (viewModel.VerticalAxisType == "Telerik.Windows.Controls.ChartView.RadialAxis")
                viewModel.VerticalAxisType = "RadialAxis";

            //customize Polar/Radial display string
            if (viewModel.PolarAxisType == "Telerik.Windows.Controls.ChartView.RadialAxis")
                viewModel.PolarAxisType = "RadialAxis";
            else if (viewModel.PolarAxisType == "Telerik.Windows.Controls.ChartView.NumericRadialAxis")
                viewModel.PolarAxisType = "NumericRadialAxis";
            else if (viewModel.PolarAxisType == "Telerik.Windows.Controls.ChartView.PolarAxis")
                viewModel.PolarAxisType = "PolarAxis";
            if (viewModel.RadialAxisType == "Telerik.Windows.Controls.ChartView.RadialAxis")
                viewModel.RadialAxisType = "RadialAxis";
            else if (viewModel.RadialAxisType == "Telerik.Windows.Controls.ChartView.NumericRadialAxis")
                viewModel.RadialAxisType = "NumericRadialAxis";
            else if (viewModel.RadialAxisType == "Telerik.Windows.Controls.ChartView.PolarAxis")
                viewModel.RadialAxisType = "PolarAxis";
        }


        private void btnLinearCategoricalAxis_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            BarSeries barSeries = new BarSeries();
            barSeries.ItemsSource = data1;
            RadChart1.VerticalAxis = new LinearAxis() { Title = "Vertical Linear Axis" };
            RadChart1.HorizontalAxis = new CategoricalAxis() { Title = "Horizontal Categorical Axis" };
            barSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Title" };
            barSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
            barSeries.ShowLabels = true;
            RadChart1.Series.Add(barSeries);
            UpdateAxisTypesInfo();
        }

        private void btnCategoricalLinearAxis_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            BarSeries barSeries = new BarSeries();
            barSeries.ItemsSource = data1;
            barSeries.ShowLabels = true;
            RadChart1.VerticalAxis = new CategoricalAxis() { Title = "Vertical Categorical Axis" };
            RadChart1.HorizontalAxis = new LinearAxis() { Title = "Horizontal Linear Axis" };
            barSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Title" };
            barSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
            RadChart1.Series.Add(barSeries);
            UpdateAxisTypesInfo();
        }

        private void btnLogarithmicCategoricalAxis_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            BarSeries barSeries = new BarSeries();
            barSeries.ItemsSource = data1;
            RadChart1.VerticalAxis = new LogarithmicAxis() { Title = "Vertical Logarithmic Axis" };
            RadChart1.HorizontalAxis = new CategoricalAxis() { Title = "Horizontal Categorical Axis" };
            barSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Title" };
            barSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
            barSeries.ShowLabels = true;
            RadChart1.Series.Add(barSeries);
            UpdateAxisTypesInfo();
        }

        private void btnCategoricalLogarithmicAxis_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            BarSeries barSeries = new BarSeries();
            barSeries.ItemsSource = data1;
            RadChart1.VerticalAxis = new CategoricalAxis() { Title = "Vertical Categorical Axis" };
            RadChart1.HorizontalAxis = new LogarithmicAxis() { Title = "Horizontal Logarithmic Axis" };
            barSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Title" };
            barSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
            barSeries.ShowLabels = true;
            RadChart1.Series.Add(barSeries);
            UpdateAxisTypesInfo();
        }

        private void btnLinearDateTimeContinuousAxis_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            LineSeries lineSeries = new LineSeries() { ClipToPlotArea = false };
            RadChart1.VerticalAxis = new LinearAxis() { Title = "Vertical Linear Axis" };
            RadChart1.HorizontalAxis = new DateTimeContinuousAxis()
            {
                LabelFitMode = Telerik.Charting.AxisLabelFitMode.Rotate,
                LabelFormat = "MMM dd yyy",
                Title = "Horizontal DateTimeContinous Axis"
            };
            lineSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Date" };
            lineSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
            lineSeries.ItemsSource = data1;
            lineSeries.ShowLabels = true;
            RadChart1.Series.Add(lineSeries);
            UpdateAxisTypesInfo();
        }

        private void btnDateTimeContinuousLinearAxis_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            LineSeries lineSeries = new LineSeries() { ClipToPlotArea = false };
            RadChart1.VerticalAxis = new DateTimeContinuousAxis()
            {
                LabelFormat = "MMM dd yyy",
                Title = "Vertical DateTimeContinuous Axis"
            };
            RadChart1.HorizontalAxis = new LinearAxis() { Title = "Horizontal Linear Axis" };
            lineSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Date" };
            lineSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
            lineSeries.ItemsSource = data1;
            lineSeries.ShowLabels = true;
            RadChart1.Series.Add(lineSeries);
            UpdateAxisTypesInfo();
        }

        private void btnLinearLinearAxis_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            ScatterPointSeries scatterPointSeries = new ScatterPointSeries() { ClipToPlotArea = false };
            scatterPointSeries.PointTemplate = this.Resources["scatterEllipse"] as DataTemplate;
            scatterPointSeries.XValueBinding = new GenericDataPointBinding<ChartData, double?>() { ValueSelector = selector => selector.Low };
            scatterPointSeries.YValueBinding = new GenericDataPointBinding<ChartData, double?>() { ValueSelector = selector => selector.High };
            scatterPointSeries.ItemsSource = data1;
            RadChart1.VerticalAxis = new LinearAxis() { Title = "Vertical Linear Axis" };
            RadChart1.HorizontalAxis = new LinearAxis() { Title = "Horizontal Linear Axis" };
            scatterPointSeries.ShowLabels = true;
            RadChart1.Series.Add(scatterPointSeries);
            UpdateAxisTypesInfo();
        }

        private void btnLogarithmicLinearAxis_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            ScatterPointSeries scatterPointSeries = new ScatterPointSeries() { ClipToPlotArea = false };
            scatterPointSeries.PointTemplate = this.Resources["scatterEllipse"] as DataTemplate;
            scatterPointSeries.XValueBinding = new GenericDataPointBinding<ChartData, double?>() { ValueSelector = selector => selector.Low };
            scatterPointSeries.YValueBinding = new GenericDataPointBinding<ChartData, double?>() { ValueSelector = selector => selector.High };
            scatterPointSeries.ItemsSource = data1;
            RadChart1.VerticalAxis = new LogarithmicAxis() { Title = "Vertical Logarithmic Axis" };
            RadChart1.HorizontalAxis = new LinearAxis() { Title = "Horizontal Linear Axis" };
            scatterPointSeries.ShowLabels = true;
            RadChart1.Series.Add(scatterPointSeries);
            UpdateAxisTypesInfo();
        }

        private void btnLinearLogarithmicAxis_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            ScatterPointSeries scatterPointSeries = new ScatterPointSeries() { ClipToPlotArea = false };
            scatterPointSeries.PointTemplate = this.Resources["scatterEllipse"] as DataTemplate;
            scatterPointSeries.XValueBinding = new GenericDataPointBinding<ChartData, double?>() { ValueSelector = selector => selector.Low };
            scatterPointSeries.YValueBinding = new GenericDataPointBinding<ChartData, double?>() { ValueSelector = selector => selector.High };
            scatterPointSeries.ItemsSource = data1;
            RadChart1.VerticalAxis = new LinearAxis() { Title = "Vertical Linear Axis" };
            RadChart1.HorizontalAxis = new LogarithmicAxis() { Title = "Horizontal Logarithmic Axis" };
            scatterPointSeries.ShowLabels = true;
            RadChart1.Series.Add(scatterPointSeries);
            UpdateAxisTypesInfo();
        }

        private void btnLogarithmicLogarithmicAxis_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            ScatterPointSeries scatterPointSeries = new ScatterPointSeries() { ClipToPlotArea = false };
            scatterPointSeries.PointTemplate = this.Resources["scatterEllipse"] as DataTemplate;
            scatterPointSeries.XValueBinding = new GenericDataPointBinding<ChartData, double?>() { ValueSelector = selector => selector.Low };
            scatterPointSeries.YValueBinding = new GenericDataPointBinding<ChartData, double?>() { ValueSelector = selector => selector.High };
            scatterPointSeries.ItemsSource = data1;
            RadChart1.VerticalAxis = new LogarithmicAxis() { Title = "Vertical Logarithmic" };
            RadChart1.HorizontalAxis = new LogarithmicAxis() { Title = "Horziontal Logarithmic" };
            scatterPointSeries.ShowLabels = true;
            RadChart1.Series.Add(scatterPointSeries);
            UpdateAxisTypesInfo();
        }

        private void btnLogarithmicDateTimeContinuousAxis_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            LineSeries lineSeries = new LineSeries() { ClipToPlotArea = false };
            RadChart1.VerticalAxis = new LogarithmicAxis() { Title = "Vertical Logarithmic Axis" };
            RadChart1.HorizontalAxis = new DateTimeContinuousAxis()
            {
                LabelFitMode = Telerik.Charting.AxisLabelFitMode.Rotate,
                LabelFormat = "MMM dd yyy",
                Title = "Horizontal DateTimeContinuous Axis"
            };
            lineSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Date" };
            lineSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
            lineSeries.ItemsSource = data1;
            lineSeries.ShowLabels = true;
            RadChart1.Series.Add(lineSeries);
            UpdateAxisTypesInfo();
        }

        private void btnDateTimeContinuousLogarithmicAxis_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            LineSeries lineSeries = new LineSeries() { ClipToPlotArea = false };
            RadChart1.VerticalAxis = new DateTimeContinuousAxis()
            {
                LabelFitMode = Telerik.Charting.AxisLabelFitMode.Rotate,
                LabelRotationAngle = 30,
                LabelFormat = "MMM dd yyy",
                Title = "Vertical DateTimeContinuous Axis"
            };
            RadChart1.HorizontalAxis = new LogarithmicAxis() { Title = "Horozitonal Logarithmic Axis" };
            lineSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Date" };
            lineSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
            lineSeries.ItemsSource = data1;
            lineSeries.ShowLabels = true;
            RadChart1.Series.Add(lineSeries);
            UpdateAxisTypesInfo();
        }

        private void btnDateTimeDateTime_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            LineSeries lineSeries = new LineSeries();
            RadChart1.VerticalAxis = new DateTimeContinuousAxis()
            {
                LabelRotationAngle = 30,
                LabelFormat = "MMM dd yyy",
                Title = "Vertical DateTimeContinuous Axis"
            };
            RadChart1.HorizontalAxis = new DateTimeContinuousAxis()
            {
                LabelFitMode = Telerik.Charting.AxisLabelFitMode.Rotate,
                LabelRotationAngle = 30,
                LabelFormat = "MMM dd yyy",
                Title = "Horizontal DateTimeContinuous Axis"
            };
            lineSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Date" };
            lineSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
            lineSeries.ItemsSource = data1;
            lineSeries.ShowLabels = true;
            RadChart1.Series.Add(lineSeries);
            UpdateAxisTypesInfo();
        }

        private void btnDateTimeCategorical_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            BarSeries barSeries = new BarSeries();
            barSeries.ItemsSource = data1;
            RadChart1.VerticalAxis = new DateTimeContinuousAxis()
            {
                LabelRotationAngle = 30,
                LabelFormat = "MMM dd yyy",
                Title = "Vertical DateTimeContinuous Axis"
            };
            RadChart1.HorizontalAxis = new CategoricalAxis()
            {
                LabelFitMode = Telerik.Charting.AxisLabelFitMode.Rotate,
                LabelRotationAngle = 30,
                Title = "Horizontal Categorical Axis"
            };
            barSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Title" };
            barSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
            barSeries.ItemsSource = data1;
            barSeries.ShowLabels = true;
            RadChart1.Series.Add(barSeries);
            UpdateAxisTypesInfo();
        }

        private void btnCategoricalDateTime_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            BarSeries barSeries = new BarSeries();
            barSeries.ItemsSource = data1;
            RadChart1.VerticalAxis = new CategoricalAxis()
            {
                LabelRotationAngle = 30,
                LabelFormat = "MMM dd yyy",
                Title = "Vertical Categorical Axis"
            };
            RadChart1.HorizontalAxis = new DateTimeContinuousAxis()
            {
                LabelFitMode = Telerik.Charting.AxisLabelFitMode.Rotate,
                LabelRotationAngle = 30,
                Title = "Horizontal DateTimeContinuous Axis"
            };
            barSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Title" };
            barSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
            barSeries.ItemsSource = data1;
            barSeries.ShowLabels = true;
            RadChart1.Series.Add(barSeries);
            UpdateAxisTypesInfo();
        }

        private void btnCategoricalCategorical_Click(object sender, RoutedEventArgs e)
        {
            RadChart1.Series.Clear();
            RadChart1.Visibility = System.Windows.Visibility.Visible;
            BarSeries barSeries = new BarSeries();
            barSeries.ItemsSource = data1;
            RadChart1.VerticalAxis = new CategoricalAxis()
            {
                LabelRotationAngle = 30,
                LabelFormat = "MMM dd yyy",
                Title = "Vertical Categorical Axis"
            };
            RadChart1.HorizontalAxis = new CategoricalAxis()
            {
                LabelFitMode = Telerik.Charting.AxisLabelFitMode.Rotate,
                LabelRotationAngle = 30,
                Title = "Horizontal Categorical Axis"
            };
            barSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Title" };
            barSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
            barSeries.ItemsSource = data1;
            barSeries.ShowLabels = true;
            RadChart1.Series.Add(barSeries);
            UpdateAxisTypesInfo();
        }
    }

    public class ChartData
    {
        public ChartData(string title, double? value, double? angle, double? low, double high, DateTime date)
        {
            this.Title = title;
            this.Value = value;
            this.Angle = angle;
            this.Low = low;
            this.High = high;
            this.Date = date;
        }

        public string Title { get; set; }
        public double? Value { get; set; }
        public double? Angle { get; set; }
        public double? Low { get; set; }
        public double? High { get; set; }

        public DateTime Date { get; set; }
    }
}
