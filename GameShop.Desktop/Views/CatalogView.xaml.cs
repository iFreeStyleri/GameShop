using GameShop.Desktop.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameShop.Desktop.Views
{
    /// <summary>
    /// Логика взаимодействия для CatalogView.xaml
    /// </summary>
    public partial class CatalogView : UserControl
    {
        public CatalogView()
        {
            InitializeComponent();
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (CatalogViewModel)DataContext;
            var button = (Button)sender;
            var game = viewModel.GetGameAcceptOrder((int)button.Tag);
            if(game != null)
            {
                var orderAcceptWindow = new OrderAcceptWindow(game);
                if(orderAcceptWindow.ShowDialog() == true)
                {
                    viewModel.PlaceOrder(game);
                }
            }
        }
    }
}
