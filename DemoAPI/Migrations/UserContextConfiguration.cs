namespace DemoAPI.Migrations.MigrationsUserContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class UserContextConfiguration : DbMigrationsConfiguration<DemoAPI.Models.UserContext>
    {
        public UserContextConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DemoAPI.Models.UserContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
