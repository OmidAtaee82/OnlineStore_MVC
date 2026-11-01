using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cart
    {

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<CartItem>? CartItems { get; set; } = new List<CartItem>();
        public User? User { get; set; }

    }
}
