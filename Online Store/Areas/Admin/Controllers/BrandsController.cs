using Entity;
using Microsoft.AspNetCore.Mvc;
using Online_Store.ViewModel.Brands;
using ServicesContract;

namespace Online_Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {

        protected readonly IWebHostEnvironment _env;
        protected readonly IBrandService _brandService;

        public BrandsController(IWebHostEnvironment env , IBrandService brand)
        {
            _env = env;
            _brandService = brand;
        }

        [Route("/admin/brands")]
        public IActionResult Brands()
        {
            var result = _brandService.GetAllBrands().Select(x => new BrandVM
            {
                Id = x.Id , 
                Name = x.Name , 
                BrandImage = x.BrandImage
            }).ToList();

            return View(result);
        }


        [Route("/admin/brands/{id}")]
        public IActionResult Brand(int id)
        {
            var brand = _brandService.GetBrand(id);
            var model = new BrandVM();

            if(brand != null)
            {
                model.Id = brand.Id;
                model.Name = brand.Name;
                model.BrandImage = brand.BrandImage;
            }

            return View(model);

        }


        [HttpGet]
        [Route("/admin/brands/create")]
        public IActionResult BrandsCreate()
        {
            return View();
        }

        [HttpPost]
        [Route("/admin/brands/create")]
        public IActionResult BrandsCreate(BrandCreateVM model)
        {

            string imgPath = "";

            if(model.BrandImage != null)
            {

                string fileName = model.BrandImage.FileName;
                string path = Path.Combine(_env.WebRootPath , "img" , fileName);
                using (var path_file = new FileStream(path , FileMode.Create))
                {
                    model.BrandImage.CopyTo(path_file);
                }

                imgPath = "/img/" + fileName;

            }

            _brandService.AddBrand(new Brand
            {
                Id = model.Id , 
                Name = model.Name , 
                BrandImage = imgPath
            });

            return RedirectToAction("Brands");

        }


        [HttpGet]
        [Route("/admin/brands/edit/{id}")]
        public IActionResult BrandsEdit(int id)
        {
            var brand = _brandService.GetBrand(id);
            var model = new BrandEditVM();

            if(brand != null)
            {
                model.Id = brand.Id;
                model.Name = brand.Name;
                model.ViewImage = brand.BrandImage;
            }

            return View(model);
        }

    }
}
