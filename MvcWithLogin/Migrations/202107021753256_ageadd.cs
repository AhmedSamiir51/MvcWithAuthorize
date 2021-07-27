namespace MvcWithLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ageadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Age");
        }
    }
}
