using System.Data.Entity;

namespace Twitter.Models.Main
{
    public class EbayModelsDB : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);
        }
    }
}