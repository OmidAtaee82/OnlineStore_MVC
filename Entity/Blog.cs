using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Blog
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان بلاگ الزامی است")]
        [StringLength(200)]
        public string Title { get; set; }

        [Required(ErrorMessage = "توضیح بلاگ الزامی است")]
        public string Description { get; set; }

        [Required(ErrorMessage = "عکس بلاگ الزامی است")]
        public string BlogImage { get; set; }

        public DateTime? PublishedDate { get; set; }

    }
}
