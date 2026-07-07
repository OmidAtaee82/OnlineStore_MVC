using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "نام دسته بندی الزامی است")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "عکس دسته بندی الزامی است")]
        public string CategoryImage { get; set; }

        public int? ParentId { get; set; }

        public Category? Parent { get; set; }

        public ICollection<Category> Children { get; set; } = new List<Category>();

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
