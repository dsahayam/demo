using HRSystems.Entity;
using HRSystems.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace SSquare_HRSystem.DataRepository
{
    public class HRSystemsContext : DbContext
    {
        public DbSet<EmployeeEntity> EmployeesEntity { get; set; }
        public DbSet<RolesEntity> RolesEntity { get; set; }
        public DbSet<EmployeeRolesEntity> EmployeesRolesEntity { get; set; }

        public DbSet<EmployeeInfoEntity> EmployeesInfoEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=HRSystems;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Server=localhost;Database=HRSystems;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False",
                                        options => options.EnableRetryOnFailure()
                                    );
        }
    }
}

/*E
 * 'DbContextOptionsBuilder' does not contain a definition for 'UseSqlServer' and no accessible extension methods 'UseSqlServer' accepting first argument type 'DbContextOptionsBuilder'
 * 
public class SchoolContext : DbContext
{
    //entities
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;");
    }
}
*/