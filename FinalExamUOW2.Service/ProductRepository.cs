using FinalExamUOW2.Data.Contexts;
using FinalExamUOW2.Data.Interfaces;
using FinalExamUOW2.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamUOW2.Service
{
    public class ProductRepository : Repository<Product, DataContext3>, IProductRepository
    {
        private readonly DataContext3 _dataContext;

        public ProductRepository(DataContext3 dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Product> GetByCategoryId(int id)
        {
            return _dataContext.Products.Where(x => x.CategoryID == id);
        }
    }
}
