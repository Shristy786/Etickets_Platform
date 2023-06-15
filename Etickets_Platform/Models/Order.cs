using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }
        [ForeignKey (nameof(UserId))]

        public ApplicationUser User { get; set; }

        public List<OrderItem> orderItems { get; set; }
    }
}
