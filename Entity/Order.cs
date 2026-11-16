using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Order
    {

        [Key]
        public int Id { get; set; }
        public string UserId { get; set; } = null !;
        public ApplicationUser User { get; set; } = null!;
        public string Address { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Status { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();

    }
}
