using FinalExamUOW2.Data.Contexts;
using FinalExamUOW2.Data.Interfaces;
using FinalExamUOW2.Data.Models;

namespace FinalExamUOW2.Service
{
    public class CategoryRepository : Repository<Category, DataContext3>, ICategoryRepository
    {
        private readonly DataContext3 _dataContext;

        public CategoryRepository(DataContext3 dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
