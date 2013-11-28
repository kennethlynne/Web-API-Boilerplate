using System.Data.Entity;

namespace Boilerplate.Data.Configuration
{
    class DbInitializer : DropCreateDatabaseAlways<BoilerplateDbContext>
    {
        protected override void Seed(BoilerplateDbContext context)
        {
        }
    }
}
