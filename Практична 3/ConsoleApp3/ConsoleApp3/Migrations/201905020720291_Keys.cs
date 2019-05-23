namespace ConsoleApp3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Keys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diagnoses",
                c => new
                    {
                        DiagnosesID = c.Int(nullable: false, identity: true),
                        Comments = c.String(maxLength: 250),
                        Name = c.String(maxLength: 50),
                        PatientId = c.Int(nullable: false),
                        Patients_PatientsID = c.Int(),
                    })
                .PrimaryKey(t => t.DiagnosesID)
                .ForeignKey("dbo.Patients", t => t.Patients_PatientsID)
                .Index(t => t.Patients_PatientsID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientsID = c.Int(nullable: false, identity: true),
                        Address = c.String(maxLength: 250),
                        Email = c.String(maxLength: 80),
                        FirstName = c.String(maxLength: 50),
                        HasInsurance = c.Boolean(nullable: false),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PatientsID);
            
            CreateTable(
                "dbo.PatientMedicaments",
                c => new
                    {
                        PatientMedicamentId = c.Int(nullable: false, identity: true),
                        PatientsId = c.Int(nullable: false),
                        MedicamentsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientMedicamentId)
                .ForeignKey("dbo.Medicaments", t => t.MedicamentsId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientsId, cascadeDelete: true)
                .Index(t => t.PatientsId)
                .Index(t => t.MedicamentsId);
            
            CreateTable(
                "dbo.Medicaments",
                c => new
                    {
                        MedicamentsID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MedicamentsID);
            
            CreateTable(
                "dbo.Visitations",
                c => new
                    {
                        VisitationsID = c.Int(nullable: false, identity: true),
                        Comments = c.String(maxLength: 250),
                        Date = c.DateTime(nullable: false),
                        PatientId = c.Int(nullable: false),
                        Patients_PatientsID = c.Int(),
                    })
                .PrimaryKey(t => t.VisitationsID)
                .ForeignKey("dbo.Patients", t => t.Patients_PatientsID)
                .Index(t => t.Patients_PatientsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitations", "Patients_PatientsID", "dbo.Patients");
            DropForeignKey("dbo.PatientMedicaments", "PatientsId", "dbo.Patients");
            DropForeignKey("dbo.PatientMedicaments", "MedicamentsId", "dbo.Medicaments");
            DropForeignKey("dbo.Diagnoses", "Patients_PatientsID", "dbo.Patients");
            DropIndex("dbo.Visitations", new[] { "Patients_PatientsID" });
            DropIndex("dbo.PatientMedicaments", new[] { "MedicamentsId" });
            DropIndex("dbo.PatientMedicaments", new[] { "PatientsId" });
            DropIndex("dbo.Diagnoses", new[] { "Patients_PatientsID" });
            DropTable("dbo.Visitations");
            DropTable("dbo.Medicaments");
            DropTable("dbo.PatientMedicaments");
            DropTable("dbo.Patients");
            DropTable("dbo.Diagnoses");
        }
    }
}
