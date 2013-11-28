using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Data
{
    class DbInitializer : DropCreateDatabaseAlways<BoilerplateDbContext>
    {
        protected override void Seed(BoilerplateDbContext context)
        {
        }
    }
}
