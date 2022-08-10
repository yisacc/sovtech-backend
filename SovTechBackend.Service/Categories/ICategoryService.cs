
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SovTechBackend.Service.categories
{
    public interface ICategoryService
    {
        Task<List<string>> GetCategories();
        Task<List<string>>SearchCategory(string query);
    }
}
