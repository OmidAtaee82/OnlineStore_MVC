using Entity;
using Microsoft.AspNetCore.Mvc;
using Online_Store.ViewModel.Categories;
using ServicesContract;

namespace Online_Store.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoriesController : Controller
    {

        protected readonly IWebHostEnvironment _env;
        protected readonly ICategoryService _categoryService;

        public CategoriesController(IWebHostEnvironment env , ICategoryService category)
        {
            _env = env;
            _categoryService = category;
        }

        [Route("/admin/categories")]
        public IActionResult Categories()
        {

            var category = _categoryService.GetAllCategory();
            var result = category.Select(x => new CategoryVM
            {
                Name = x.Name , 
                CategoryImage = x.CategoryImage , 
                ParentName = x.Parent == null ? "دسته اصلی" : x.Parent.Name,
            }).ToList();
            return View(result);
        }


        [HttpGet]
        [Route("/admin/categories/create")]
        public IActionResult CategoriesCreate()
        {
            var category = _categoryService.GetAllCategory().Select(x=>new CategoryVM
            {
                Id = x.Id , 
                Name = x.Name , 
                ParentName = x.Parent?.Name , 
                CategoryImage = x.CategoryImage , 
            }).ToList();
            return View(category);
        }

        [HttpPost]
        [Route("/admin/categories/create")]
        public IActionResult CategoriesCreate(CategoryCreateVM model)
        {

            string imgPath = "";

            if (model.CategoryImage != null)
            {
                string fileName = model.CategoryImage.FileName;
                string path = Path.Combine(_env.WebRootPath, "img", fileName);
                using (var path_file = new FileStream(path, FileMode.Create))
                {
                    model.CategoryImage.CopyTo(path_file);
                }

                imgPath = "/img/" + fileName;

            }

            _categoryService.AddCategory(new Category
            {
                Name = model.Name,
                CategoryImage = imgPath,
                ParentId = model.ParentId == 0 ? null : model.ParentId
            });
            return RedirectToAction("Categories");
        }

    }
}
