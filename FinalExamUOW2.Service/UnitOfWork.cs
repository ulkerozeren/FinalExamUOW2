using FinalExamUOW2.Data.Contexts;
using FinalExamUOW2.Data.Interfaces;

namespace FinalExamUOW2.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext1 _dataContext1;
        private readonly DataContext2 _dataContext2;
        private readonly DataContext3 _dataContext3;
        public UnitOfWork(DataContext1 dataContext1, DataContext2 dataContext2, DataContext3 dataContext3)
        {
            _dataContext1 = dataContext1;
            _dataContext2 = dataContext2;
            _dataContext3 = dataContext3;
            UserRepository = new UserRepository(dataContext1);
            UserLogRepository = new UserLogRepository(dataContext2);
            CategoryRepository = new CategoryRepository(dataContext3);
            ProductRepository = new ProductRepository(dataContext3);
        }

        public IUserRepository UserRepository { get; set; }
        public IUserLogRepository UserLogRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }

        public int Complete()
        {
            return _dataContext1.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext1.Dispose();
            _dataContext2.Dispose();
        }
    }
}
