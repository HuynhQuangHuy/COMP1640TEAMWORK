namespace TeamWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryOfIdeas",
                c => new
                {
                    CategoryOfIdeaID = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.CategoryOfIdeaID);

            CreateTable(
                "dbo.Ideas",
                c => new
                {
                    IdeaID = c.Int(nullable: false, identity: true),
                    NameOfIdea = c.String(),
                    CategoryOfIdeaID = c.Int(nullable: false),
                    DateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.IdeaID);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    ProductID = c.Int(nullable: false, identity: true),
                    NameOfProduct = c.String(),
                    CategoryOfProductID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ProductID);
        }
           
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Products");
            DropTable("dbo.Ideas");
            DropTable("dbo.CategoryOfIdeas");
        }
    }
}
