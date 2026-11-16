using System.ComponentModel.DataAnnotations;

namespace Online_Store.ViewModel.Auth
{
    public class RegisterVM
    {

        [Required(ErrorMessage = "وارد کردن نام و نام خانوادگی الزامی است")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "وارد کردن ایمیل الزامی است")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد کردن رمز عبور الزامی است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
