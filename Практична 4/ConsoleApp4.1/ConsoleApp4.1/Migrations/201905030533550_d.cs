namespace ConsoleApp4._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Courses", "StartDate", c => c.DateTime());
            AlterColumn("dbo.HomeworkSubmissions", "SubmissionTime", c => c.DateTime());
            AlterColumn("dbo.Students", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Birthday", c => c.DateTime());
            AlterColumn("dbo.HomeworkSubmissions", "SubmissionTime", c => c.DateTime());
            AlterColumn("dbo.Courses", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Courses", "EndDate", c => c.DateTime());
        }
    }
}
