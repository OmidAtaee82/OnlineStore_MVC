using Entity;

namespace Online_Store.ViewModel.Categories
{
    public class CategoryCreateVM
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile CategoryImage { get; set; }
        public int? ParentId { get; set; }
        public Category CategoryName { get; set; }

        public List<CategoryVM> Categories { get; set; } = new();

    }
}
