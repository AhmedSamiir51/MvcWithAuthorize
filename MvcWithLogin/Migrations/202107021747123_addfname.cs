namespace MvcWithLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Fname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Lname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Lname");
            DropColumn("dbo.AspNetUsers", "Fname");
        }
    }
}
