using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ProductImage { get; set; }
        public decimal Price{ get; set; }
        public int? Discount { get; set; }
        public string? Color { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }

    }
}
