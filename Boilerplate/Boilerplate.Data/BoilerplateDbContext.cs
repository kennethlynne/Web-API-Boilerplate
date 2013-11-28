using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate.Models;

namespace Boilerplate.Data
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
    }
}
