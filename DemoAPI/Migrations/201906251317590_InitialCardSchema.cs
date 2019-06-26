namespace DemoAPI.Migrations.MigrationsCardContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCardSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                {
                    CardId = c.Int(nullable: false, identity: true),
                    MarketName = c.String(nullable: false),
                    UserId = c.Int(nullable: false)
                })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true);

              
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "UserId", "dbo.Users");
            DropTable("dbo.Cards");
        }
    }
}
