using ChemistryIS.ViewModels;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ChemistryIS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PeriodicTableViewModel viewModel = new PeriodicTableViewModel();
            
            
        }
    }
}