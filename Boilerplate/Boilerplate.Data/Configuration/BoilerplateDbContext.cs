using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Boilerplate.Data.Configuration
{
    public class BoilerplateDbContext : DbContext
    {
        public BoilerplateDbContext()
            : base("Boilerplate")
        {
        }

        static BoilerplateDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}