using FinalExamUOW2.Data.Interfaces;
using FinalExamUOW2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalExamUOW2.Data.Contexts
{
    public class DataContext1 : DbContext
    {
        public DataContext1(DbContextOptions<DataContext1> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbContext Current => this;
    }
}
