namespace WebApiToken.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationKutuphane : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kitaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        kitapAd = c.String(),
                        yazarAd = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kitaps");
        }
    }
}
