using Boilerplate.Data.Configuration.EntityFramework;
using Boilerplate.Models;
using System.Data.Entity;

namespace Boilerplate.Data.Configuration
{
    public class DbInitializer : DropCreateDatabaseAlways<BoilerplateDbContext>
    {
        protected override void Seed(BoilerplateDbContext context)
        {
            UnitOfWork uow = new UnitOfWork(context);

            uow.ArticleRepository.Insert(new Article { Body = "<p>Heyo content!</p>", Title = "Title" , Ignored = "NOT OUTPUTTEDEDED"});
            uow.SaveChanges();
        }
    }
}