namespace ConsoleApp4._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        EndDate = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 100),
                        Price = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.HomeworkSubmissions",
                c => new
                    {
                        HomeworkSubmissionId = c.Int(nullable: false, identity: true),
                        ContentType = c.String(),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        SubmissionTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HomeworkSubmissionId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Birthday = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 100),
                        PhoneNumber = c.String(maxLength: 10),
                        RegisteredOn = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        StudentCourseId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentCourseId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        ResourceType = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.ResourceId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resources", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.HomeworkSubmissions", "StudentId", "dbo.Students");
            DropForeignKey("dbo.HomeworkSubmissions", "CourseId", "dbo.Courses");
            DropIndex("dbo.Resources", new[] { "CourseId" });
            DropIndex("dbo.StudentCourses", new[] { "CourseId" });
            DropIndex("dbo.StudentCourses", new[] { "StudentId" });
            DropIndex("dbo.HomeworkSubmissions", new[] { "StudentId" });
            DropIndex("dbo.HomeworkSubmissions", new[] { "CourseId" });
            DropTable("dbo.Resources");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Students");
            DropTable("dbo.HomeworkSubmissions");
            DropTable("dbo.Courses");
        }
    }
}
