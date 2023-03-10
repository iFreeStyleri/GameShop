using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Domain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public Account Account { get; set; }
        public Game Game { get; set; }
        public OrderState State { get; set; }
    }
}
