namespace Online_Store.ViewModel.Product
{
    public class ProductVM
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ProductImage { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string? Color { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }

    }
}
