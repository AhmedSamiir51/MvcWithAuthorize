namespace MvcWithLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classesadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stu_Courses",
                c => new
                    {
                        St_id = c.Int(nullable: false),
                        Courses_id = c.Int(nullable: false),
                        Grade = c.Int(nullable: true),
                    })
                .PrimaryKey(t => new { t.St_id, t.Courses_id })
                .ForeignKey("dbo.Courses", t => t.Courses_id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.St_id, cascadeDelete: true)
                .Index(t => t.St_id)
                .Index(t => t.Courses_id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Age = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        Dept_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.Dept_id, cascadeDelete: true)
                .Index(t => t.Dept_id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dep_Courses",
                c => new
                    {
                        Dep_id = c.Int(nullable: false),
                        Courses_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dep_id, t.Courses_id })
                .ForeignKey("dbo.Courses", t => t.Courses_id, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Dep_id, cascadeDelete: true)
                .Index(t => t.Dep_id)
                .Index(t => t.Courses_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dep_Courses", "Dep_id", "dbo.Departments");
            DropForeignKey("dbo.Dep_Courses", "Courses_id", "dbo.Courses");
            DropForeignKey("dbo.Stu_Courses", "St_id", "dbo.Students");
            DropForeignKey("dbo.Students", "Dept_id", "dbo.Departments");
            DropForeignKey("dbo.Stu_Courses", "Courses_id", "dbo.Courses");
            DropIndex("dbo.Dep_Courses", new[] { "Courses_id" });
            DropIndex("dbo.Dep_Courses", new[] { "Dep_id" });
            DropIndex("dbo.Students", new[] { "Dept_id" });
            DropIndex("dbo.Stu_Courses", new[] { "Courses_id" });
            DropIndex("dbo.Stu_Courses", new[] { "St_id" });
            DropTable("dbo.Dep_Courses");
            DropTable("dbo.Departments");
            DropTable("dbo.Students");
            DropTable("dbo.Stu_Courses");
            DropTable("dbo.Courses");
        }
    }
}
