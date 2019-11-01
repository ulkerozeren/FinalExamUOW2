using FinalExamUOW2.Data.Interfaces;
using FinalExamUOW2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalExamUOW2.Data.Contexts
{
    public class DataContext3 :  DbContext
    {
        public DataContext3(DbContextOptions<DataContext3> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbContext Current => this;
    }
}
