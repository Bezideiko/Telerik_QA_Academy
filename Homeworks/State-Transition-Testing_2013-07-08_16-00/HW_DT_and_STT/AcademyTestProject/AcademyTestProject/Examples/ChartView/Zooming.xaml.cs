using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls.ChartView;
using System.Windows.Printing;
using System.Windows.Controls.Primitives;

namespace Examples.ChartView
{
    public partial class Zooming : UserControl
    {
        ObservableCollection<ChartData> data1;
        public Zooming()
        {
            InitializeComponent();
            
        }

        private void btnLoadChart_Click(object sender, RoutedEventArgs e)
        {
            data1 = new ObservableCollection<ChartData>();
            Random r = new Random();
            for (int i = 0; i < 15; i++)
            {
                data1.Add(new ChartData() { Title = "Label " + i, Value = r.Next(10, 50) });
            }

            if (RadChart1.Series.Count > 0)
            {
                RadChart1.Series.Clear();
            }
            BarSeries barSeries = new BarSeries();
            RadChart1.VerticalAxis = new LinearAxis();
            RadChart1.HorizontalAxis = new CategoricalAxis();
            barSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Title" };
            barSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
            barSeries.ItemsSource = data1;
            barSeries.ShowLabels = true;
            RadChart1.Series.Add(barSeries);
        }

        private void btnApplyZoom_Click(object sender, RoutedEventArgs e)
        {
            this.RadChart1.Zoom = new Size(2, 1);
            this.RadChart1.Behaviors.Add(new ChartPanAndZoomBehavior());
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.RadChart1.Behaviors.Clear();
            RadChart1.Series.Clear();
        }

        Popup popup;
        Border border;
        StackPanel panel1;
        TextBlock textblock1;
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Chart has been sent for printing...");
            popup = new Popup() { Name = "Popup" };
            border = new Border() { Name = "Border" };
            panel1 = new StackPanel() { Name = "Panel" };
            textblock1 = new TextBlock() { Name = "Textblock" };

            border.BorderBrush = new SolidColorBrush(Colors.DarkGray);
            border.BorderThickness = new Thickness(3.0);

            panel1.Background = new SolidColorBrush(Colors.LightGray);
            textblock1.Text = "Chart has been sent for printing...";
            textblock1.Margin = new Thickness(30.0);
            panel1.Children.Add(textblock1);
            Button button = new Button(){ Content = "OK", Width = 30, Height = 20, Margin = new Thickness(5.0)};
            button.Click +=new RoutedEventHandler(button_Click);
            panel1.Children.Add(button);

            border.Child = panel1;
            popup.Child = border;
            popup.HorizontalOffset = 613;
            popup.VerticalOffset = 375;
            popup.IsOpen = true;
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        public class ChartData
        {
            public string Title { get; set; }
            public double? Value { get; set; }
        }
    }
}
