using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Brand
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "نام برند الزامی است")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "عکس برند الزامی است")]
        public string BrandImage { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
