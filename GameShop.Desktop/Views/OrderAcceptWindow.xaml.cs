using GameShop.Domain.Entities;
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
    /// Логика взаимодействия для OrderAcceptWindow.xaml
    /// </summary>
    public partial class OrderAcceptWindow : Window
    {
        private readonly Game _game;
        public OrderAcceptWindow(Game game)
        {
            InitializeComponent();
            GameName.Text = game.Name;
            GameGenre.Text = game.Genre.ToString();
            GameCost.Text = game.Cost.ToString();
            _game = game;
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
           => DialogResult = true;

        private void Cancel_Click(object sender, RoutedEventArgs e)
            => Cancel();


        private void Cancel()
        {
            DialogResult = false;
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
            => Cancel();

        private void UpPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try { DragMove(); } catch { }
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
