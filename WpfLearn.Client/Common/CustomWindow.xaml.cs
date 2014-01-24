using System;
using System.Windows;


namespace WpfLearn.Client
{
    public partial class CustomWindow
    {
        public CustomWindow(ViewModel viewModel)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;

            DataContext = viewModel;
        }
    }
}
