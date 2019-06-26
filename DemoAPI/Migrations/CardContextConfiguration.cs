namespace DemoAPI.Migrations.MigrationsCardContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class CardContextConfiguration : DbMigrationsConfiguration<DemoAPI.Models.CardContext>
    {
        public CardContextConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DemoAPI.Models.CardContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
