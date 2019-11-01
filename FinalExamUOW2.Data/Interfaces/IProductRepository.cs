using FinalExamUOW2.Data.Models;
using System.Collections.Generic;

namespace FinalExamUOW2.Data.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetByCategoryId(int id);
    }
}
