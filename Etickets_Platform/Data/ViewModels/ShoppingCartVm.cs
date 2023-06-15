using Etickets_Platform.Data.cart;
using Etickets_Platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Data.ViewModels
{
    public class ShoppingCartVm
    {
        public ShoppingCart ShoppingCart { get; set; }

        public double ShoppingCartTotal { get; set; }
    }
}
