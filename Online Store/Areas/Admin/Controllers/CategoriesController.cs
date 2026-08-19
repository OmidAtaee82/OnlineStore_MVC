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
                Id = x.Id , 
                Name = x.Name , 
                CategoryImage = x.CategoryImage , 
                ParentName = x.Parent == null ? "دسته اصلی" : x.Parent.Name,
            }).ToList();
            return View(result);
        }


        [Route("/admin/categories/{id}")]
        [HttpGet]
        public IActionResult Category(int id)
        {
            var category = _categoryService.GetCategory(id);
            var model = new CategoryVM();

            if(category != null)
            {
                model.Id = category.Id;
                model.Name = category.Name;
                model.ParentName = category.Parent?.Name;
                model.CategoryImage = category.CategoryImage;
            }

            return View(model);
        }


        [HttpGet]
        [Route("/admin/categories/create")]
        public IActionResult CategoriesCreate()
        {
            var category = _categoryService.GetAllCategory()
                .Where(x=>x.ParentId == null)
                .Select(x=>new CategoryVM
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


        [HttpGet]
        [Route("/admin/categories/edit/{id}")]
        public IActionResult CategoriesEdit(int id)
        {

            var category = _categoryService.GetCategory(id);

            var model = new CategoryEditVM();

            if(category != null)
            {
                model.Id = category.Id;
                model.Name = category.Name;
                model.CategoryImage = category.CategoryImage;
                model.ParentId = category.ParentId;
                model.Categories = _categoryService.GetAllCategory()
                    .Where(x=>x.ParentId == null)
                    .Select(x=>new CategoryVM
                {
                    Id = x.Id , 
                    Name = x.Name , 
                    CategoryImage = x.CategoryImage , 
                    ParentName = x.Parent?.Name
                }).ToList();
            }

            return View(model);
        }


        [HttpPost]
        [Route("/admin/categories/edit/{id}")]
        public IActionResult CategoriesEdit(int id , CategoryEditVM model)
        {

            var category = _categoryService.GetCategory(id);

            if (category != null)
            {
                category.Id = model.Id;
                category.Name = model.Name;
                category.ParentId = model.ParentId;
                if (model.Image != null)
                {
                    string fileName = model.Image.FileName;
                    string path = Path.Combine(_env.WebRootPath, "img", fileName);
                    using (var path_file = new FileStream(path, FileMode.Create))
                    {
                        model.Image.CopyTo(path_file);
                    }

                    category.CategoryImage = "/img/" + fileName;

                }

                _categoryService.UpdateCategory(category);

            }

            return RedirectToAction("Categories");

        }


        [HttpPost]
        [Route("/admin/categories/delete/{id}")]
        public IActionResult CategoriesDelete(int id)
        {
            var category = _categoryService.GetCategory(id);

            if(category != null)
            {
                _categoryService.DeleteCategory(id);
            }

            return RedirectToAction("Categories");
        }

    }
}
