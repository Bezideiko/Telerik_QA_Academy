﻿#pragma checksum "C:\Users\Angel\Desktop\AcademyTestProject\AcademyTestProject\Examples\ChartView\Zooming.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E89167D5E5E22089498E73FCCC0762C1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18046
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Examples.ChartView {
    
    
    public partial class Zooming : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button btnLoadChart;
        
        internal System.Windows.Controls.Button btnApplyZoom;
        
        internal System.Windows.Controls.Button btnClear;
        
        internal System.Windows.Controls.Button btnPrint;
        
        internal Telerik.Windows.Controls.RadCartesianChart RadChart1;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Examples;component/ChartView/Zooming.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.btnLoadChart = ((System.Windows.Controls.Button)(this.FindName("btnLoadChart")));
            this.btnApplyZoom = ((System.Windows.Controls.Button)(this.FindName("btnApplyZoom")));
            this.btnClear = ((System.Windows.Controls.Button)(this.FindName("btnClear")));
            this.btnPrint = ((System.Windows.Controls.Button)(this.FindName("btnPrint")));
            this.RadChart1 = ((Telerik.Windows.Controls.RadCartesianChart)(this.FindName("RadChart1")));
        }
    }
}

