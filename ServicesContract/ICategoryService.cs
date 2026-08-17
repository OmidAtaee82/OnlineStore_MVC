using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContract
{
    public interface ICategoryService
    {

        List<Category> GetAllCategory();
        Category GetCategory(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category model);

    }
}
