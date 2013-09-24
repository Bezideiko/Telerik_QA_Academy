using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using SelectionMode = Telerik.Windows.Controls.SelectionMode;
using SelectionUnit = Telerik.Windows.Controls.GridView.GridViewSelectionUnit;
using System.Collections.ObjectModel;

namespace RadGridView
{
    public partial class MainPage : UserControl
    {
        private ObservableCollection<Player> data;

        public MainPage()
        {
            InitializeComponent(); 
            this.selectionModeCombo.ItemsSource = EnumHelper.GetNames(typeof(SelectionMode));
            this.selectionUnitCombo.ItemsSource = EnumHelper.GetNames(typeof(SelectionUnit));
            this.data = new ObservableCollection<Player>(Club.GetPlayers().Take(10).ToList());
            this.gridView.ItemsSource = this.data;
        }
    }
}
