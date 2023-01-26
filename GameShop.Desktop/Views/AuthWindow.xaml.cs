using GameShop.Desktop.API.Abstractions;
using GameShop.Desktop.ViewModels;
using GameShop.Domain.DTO;
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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private readonly IGameShopManager _manager;

        public AuthWindow(IGameShopManager manager)
        {
            InitializeComponent();
            _manager = manager;
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

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(EmailText.Text) 
                && !string.IsNullOrWhiteSpace(PasswordText.Password))
            {
                try
                {
                    var account = await _manager.Account.Login(new LoginDTO { Email = EmailText.Text, Password = PasswordText.Password });
                    if (account != null)
                    {
                        var window = App.Provider.GetRequiredService<MenuWindow>();
                        ((MenuWindowViewModel)window.DataContext).Init(account);
                        window.Show();
                        Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Неверный email или пароль");
                }
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            App.Provider.GetRequiredService<RegWindow>().Show();
            Close();
        }
    }
}
