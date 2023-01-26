using GameShop.Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameShop.Desktop.Views
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private readonly MenuWindowViewModel _viewModel;
        public MenuWindow(MenuWindowViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = viewModel;
            _viewModel.SelectedViewModel = _viewModel.CatalogViewModel;
            InitializeComponent();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void UpPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try { DragMove(); } catch { }
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            App.Provider.GetRequiredService<AuthWindow>().Show();
            Close();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SelectedViewModel = _viewModel.CatalogViewModel;
            _viewModel.CatalogViewModel.Init();
        }
    }
}
