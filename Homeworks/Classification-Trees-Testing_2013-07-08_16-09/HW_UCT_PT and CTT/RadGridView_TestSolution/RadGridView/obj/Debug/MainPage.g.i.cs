﻿#pragma checksum "D:\MG\Telerik\QA\Part_II\9.UseCaseTechnique\RadGridView_TestSolution\RadGridView\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B96E6AC3511A6B0893365A23FAD9D468"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18047
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


namespace RadGridView {
    
    
    public partial class MainPage : System.Windows.Controls.UserControl {
        
        internal Telerik.Windows.Controls.RadGridView gridView;
        
        internal System.Windows.Controls.CheckBox canUserSelectCheckBox;
        
        internal System.Windows.Controls.ComboBox selectionModeCombo;
        
        internal System.Windows.Controls.ComboBox selectionUnitCombo;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/RadGridView;component/MainPage.xaml", System.UriKind.Relative));
            this.gridView = ((Telerik.Windows.Controls.RadGridView)(this.FindName("gridView")));
            this.canUserSelectCheckBox = ((System.Windows.Controls.CheckBox)(this.FindName("canUserSelectCheckBox")));
            this.selectionModeCombo = ((System.Windows.Controls.ComboBox)(this.FindName("selectionModeCombo")));
            this.selectionUnitCombo = ((System.Windows.Controls.ComboBox)(this.FindName("selectionUnitCombo")));
        }
    }
}
