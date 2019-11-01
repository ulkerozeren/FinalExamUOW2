using System;

namespace FinalExamUOW2.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();

        IUserRepository UserRepository { get; set; }
        IUserLogRepository UserLogRepository { get; set; }
        ICategoryRepository CategoryRepository { get; set; }
        IProductRepository ProductRepository { get; set; }
    }
}
