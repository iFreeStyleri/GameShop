using GameShop.Desktop.API.Abstractions;
using GameShop.Desktop.Common;
using GameShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Desktop.ViewModels
{
    public class MenuWindowViewModel : ViewModelBase
    {
        public CatalogViewModel CatalogViewModel { get; init; }
        private readonly IGameShopManager _manager;
        private string _nickname;
        private ViewModelBase _selectedViewModel;

        public string Nickname
        {
            get => _nickname;
            set => Set(ref _nickname, value);
        }
        public ViewModelBase SelectedViewModel { 
            get => _selectedViewModel;
            set => Set(ref _selectedViewModel, value);
        }

        public MenuWindowViewModel(IGameShopManager manager, CatalogViewModel catalogViewModel)
        {
            _manager = manager;
            CatalogViewModel = catalogViewModel;
            SelectedViewModel = CatalogViewModel;
        }
        public MenuWindowViewModel()
        {
        }
        public void Init(Account account)
        {
            Nickname = account.Login;
        }
    }
}
