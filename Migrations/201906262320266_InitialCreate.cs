namespace FakeData_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personeller",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 50),
                        Soyad = c.String(),
                        Yas = c.Int(nullable: false),
                        Ulke_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ulkeler", t => t.Ulke_ID)
                .Index(t => t.Ulke_ID);
            
            CreateTable(
                "dbo.Ulkeler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personeller", "Ulke_ID", "dbo.Ulkeler");
            DropIndex("dbo.Personeller", new[] { "Ulke_ID" });
            DropTable("dbo.Ulkeler");
            DropTable("dbo.Personeller");
        }
    }
}
