namespace Online_Store.ViewModel.Brands
{
    public class BrandEditVM
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string ViewImage { get; set; }

        public IFormFile BrandImage { get; set; }

    }
}
