using Entity;
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


        public void AddCategory(Category category)
        {
            _OnlineStoreDb.Categories.Add(category);
            _OnlineStoreDb.SaveChanges();
        }

    }
}
