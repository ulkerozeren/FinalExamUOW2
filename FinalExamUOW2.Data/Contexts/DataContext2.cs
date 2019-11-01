using FinalExamUOW2.Data.Interfaces;
using FinalExamUOW2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalExamUOW2.Data.Contexts
{
    public class DataContext2 : DbContext
    {
        public DataContext2(DbContextOptions<DataContext2> options) : base(options)
        {

        }

        public DbSet<UserLog> UserLogs { get; set; }

        public DbContext Current => this;
    }
}
