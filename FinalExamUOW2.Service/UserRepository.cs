using FinalExamUOW2.Data.Contexts;
using FinalExamUOW2.Data.Interfaces;
using FinalExamUOW2.Data.Models;

namespace FinalExamUOW2.Service
{
    public class UserRepository : Repository<User, DataContext1>, IUserRepository
    {
        private readonly DataContext1 _dataContext;

        public UserRepository(DataContext1 dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
