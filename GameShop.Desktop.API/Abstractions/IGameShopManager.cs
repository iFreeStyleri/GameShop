using GameShop.Desktop.API.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Desktop.API.Abstractions
{
    public interface IGameShopManager
    {
        public IAccountService Account { get; }
        public IGameService Game { get; }
        public IOrderService Order { get; }
    }
}
