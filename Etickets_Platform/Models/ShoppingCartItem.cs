using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int id { get; set; }

        public Movie movie { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
