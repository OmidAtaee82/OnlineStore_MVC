using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ApplicationUser:IdentityUser
    {

        public string? FullName { get; set; }
        
        public Cart? Cart { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
