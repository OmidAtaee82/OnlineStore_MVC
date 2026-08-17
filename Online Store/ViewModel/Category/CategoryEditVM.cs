using Online_Store.ViewModel.Categories;

namespace Online_Store.ViewModel.Categories
{
    public class CategoryEditVM
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryImage { get; set; }
        public IFormFile? Image { get; set; }
        public int? ParentId { get; set; }
        public List<CategoryVM> Categories { get; set; }

    }
}
