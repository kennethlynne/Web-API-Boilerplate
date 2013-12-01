using System.Data.Entity;
using Boilerplate.Models;

namespace Boilerplate.Data.Configuration
{
    class DbInitializer : DropCreateDatabaseAlways<BoilerplateDbContext>
    {
        protected override void Seed(BoilerplateDbContext context)
        {
            UnitOfWork uow = new UnitOfWork(context);

            uow.MessageRepository.Insert(new Message {Text = "Hello world!"});
            uow.Save();
        }
    }
}
