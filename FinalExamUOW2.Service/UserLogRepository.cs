using FinalExamUOW2.Data.Contexts;
using FinalExamUOW2.Data.Interfaces;
using FinalExamUOW2.Data.Models;

namespace FinalExamUOW2.Service
{
    public class UserLogRepository : Repository<UserLog,DataContext2>, IUserLogRepository
    {
        private readonly DataContext2 _dataContext;

        public UserLogRepository(DataContext2 dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
