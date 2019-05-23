namespace ConsoleApp3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Doctor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorPatients",
                c => new
                    {
                        DoctorPatientId = c.Int(nullable: false, identity: true),
                        DoctorsId = c.Int(nullable: false),
                        PatientsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorPatientId)
                .ForeignKey("dbo.Doctors", t => t.DoctorsId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientsId, cascadeDelete: true)
                .Index(t => t.DoctorsId)
                .Index(t => t.PatientsId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorsID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Speciality = c.String(maxLength: 150),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.DoctorsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorPatients", "PatientsId", "dbo.Patients");
            DropForeignKey("dbo.DoctorPatients", "DoctorsId", "dbo.Doctors");
            DropIndex("dbo.DoctorPatients", new[] { "PatientsId" });
            DropIndex("dbo.DoctorPatients", new[] { "DoctorsId" });
            DropTable("dbo.Doctors");
            DropTable("dbo.DoctorPatients");
        }
    }
}
