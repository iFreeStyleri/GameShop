using GameShop.Desktop.API.Abstractions;
using GameShop.Desktop.Common;
using GameShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Desktop.ViewModels
{
    public class CatalogViewModel : ViewModelBase
    {
        private readonly IGameShopManager _manager;
        public ObservableCollection<Game> Games { get; set; }
        public CatalogViewModel(IGameShopManager manager)
        {
            _manager = manager;
            Games = new();
        }
        public async void Init()
        {
           Games.Clear();
           var games = await _manager.Game.GetAll();
           games.ForEach(f => App.Current.Dispatcher.Invoke(() => Games.Add(f)));
        }
    }
}
