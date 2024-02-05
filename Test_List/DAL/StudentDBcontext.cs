using Microsoft.EntityFrameworkCore;
using Test_List.Models.Entities;

namespace Test_List.DAL
{
    public class StudentDBcontext : DbContext
    {
        public StudentDBcontext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Student> Students { get; set; }        

    }
}
