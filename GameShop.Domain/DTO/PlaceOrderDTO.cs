using GameShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Domain.DTO
{
    public class PlaceOrderDTO
    {
        public Account Account { get; set; }
        public Game Game { get; set; }
    }
}
