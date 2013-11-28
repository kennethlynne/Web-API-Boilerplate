using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Boilerplate.Models;

namespace Boilerplate.Data.Configuration
{
    class BoilerplateDbContext : DbContext
    {
        public BoilerplateDbContext() : base("Boilerplate")
        {
            
        }

        DbSet<Message> Messages { get; set; }

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
