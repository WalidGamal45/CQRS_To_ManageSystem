using CQRS_Layer1.Dmains;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Layer1.DBContext
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options):base(options) { }
        public DbSet<Employee> Employees { get; set; }  
       
    }
}
