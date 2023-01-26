using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; } 
        public decimal Cost { get; set; }
        public List<Order> Orders { get; set; }
        public Genre Genre { get; set; }
    }
}
