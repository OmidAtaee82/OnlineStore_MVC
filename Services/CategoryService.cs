using Entity;
using Microsoft.EntityFrameworkCore;
using ServicesContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService:ICategoryService
    {

        private readonly OmidOnlineStoreDB _OnlineStoreDb;

        public CategoryService(OmidOnlineStoreDB OnliStoreDb)
        {
            _OnlineStoreDb = OnliStoreDb;
        }


        public List<Category> GetAllCategory()
        {
            return _OnlineStoreDb.Categories.Select(x=>new Category
            {
                Id = x.Id , 
                Name = x.Name , 
                CategoryImage = x.CategoryImage , 
                ParentId = x.ParentId , 
                Parent = x.Parent
            }).ToList();
        }


        public Category GetCategory(int id)
        {
            var category = _OnlineStoreDb.Categories
                .Include(x=>x.Parent)
                .FirstOrDefault(x=>x.Id == id);

            if(category == null)
            {
                throw new Exception("دسته بندی مورد نظر یافت نشد ! ");
            }

            return category;

        }


        public void AddCategory(Category category)
        {
            _OnlineStoreDb.Categories.Add(category);
            _OnlineStoreDb.SaveChanges();
        }


        public void UpdateCategory(Category model)
        {

            var category = _OnlineStoreDb.Categories.FirstOrDefault(x => x.Id == model.Id);

            if(category != null)
            {
                category.Name = model.Name;
                category.CategoryImage = model.CategoryImage;
                category.ParentId = model.ParentId;
            }

            _OnlineStoreDb.SaveChanges();

        }

    }
}
