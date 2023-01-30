using GameShop.Desktop.API.Abstractions;
using GameShop.Desktop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameShop.Domain.DTO;
using System.Collections.ObjectModel;
using GameShop.Domain.Entities;

namespace GameShop.Desktop.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        public ObservableCollection<Order> Orders { get; set; }
        private readonly IGameShopManager _manager;
        public OrderViewModel(IGameShopManager manager)
        {
            Orders = new();
            _manager = manager;
        }

        public async void Init()
        {
            Orders.Clear();
            var result = await _manager.Order
                .GetAccountOrders(new GetAccountOrdersDTO { Account = _manager.Account.AccountLogin});
            result.ForEach(f => App.Current.Dispatcher.Invoke(() => Orders.Add(f)));
        }
    }
}
