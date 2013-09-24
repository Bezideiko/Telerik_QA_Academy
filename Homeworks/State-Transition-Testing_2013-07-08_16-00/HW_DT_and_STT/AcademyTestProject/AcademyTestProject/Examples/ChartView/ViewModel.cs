using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Examples.ChartView
{
    public class ViewModel : ViewModelBase
    {
        public ViewModel()
        {
            //HorizontalAxisType = this.RadChart1.HorizontalAxis.GetType().ToString();
            //VerticalAxisType = this.RadChart1.VerticalAxis.GetType().ToString();
        }

        public string horizontalAxisType;
        public string HorizontalAxisType
        {
            get
            {
                return horizontalAxisType;
            }
            set
            {
                horizontalAxisType = value;
                OnPropertyChanged("HorizontalAxisType");
            }
        }

        public string verticalAxisType;
        public string VerticalAxisType
        {
            get
            {
                return verticalAxisType;
            }
            set
            {
                verticalAxisType = value;
                OnPropertyChanged("VerticalAxisType");
            }
        }

        public string polarAxisType;
        public string PolarAxisType
        {
            get
            {
                return polarAxisType;
            }
            set
            {
                polarAxisType = value;
                OnPropertyChanged("PolarAxisType");
            }
        }

        public string radialAxisType;
        public string RadialAxisType
        {
            get
            {
                return radialAxisType;
            }
            set
            {
                radialAxisType = value;
                OnPropertyChanged("RadialAxisType");
            }
        }

        public string verticalLocation = "Bottom";
        public string VerticalLocation
        {
            get
            {
                return verticalLocation;
            }
            set
            {
                verticalLocation = value;
                OnPropertyChanged("VerticalLocation");
            }
        }

        public string renderMode = "All";
        public string RenderMode
        {
            get
            {
                return renderMode;
            }
            set
            {
                renderMode = value;
                OnPropertyChanged("RenderMode");
            }
        }
    }


}
