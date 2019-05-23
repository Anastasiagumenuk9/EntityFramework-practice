namespace ConsoleApp3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class K : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Diagnoses", "Patients_PatientsID", "dbo.Patients");
            DropForeignKey("dbo.Visitations", "Patients_PatientsID", "dbo.Patients");
            DropIndex("dbo.Diagnoses", new[] { "Patients_PatientsID" });
            DropIndex("dbo.Visitations", new[] { "Patients_PatientsID" });
            RenameColumn(table: "dbo.Diagnoses", name: "Patients_PatientsID", newName: "PatientsId");
            RenameColumn(table: "dbo.Visitations", name: "Patients_PatientsID", newName: "PatientsId");
            AlterColumn("dbo.Diagnoses", "PatientsId", c => c.Int(nullable: false));
            AlterColumn("dbo.Visitations", "PatientsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Diagnoses", "PatientsId");
            CreateIndex("dbo.Visitations", "PatientsId");
            AddForeignKey("dbo.Diagnoses", "PatientsId", "dbo.Patients", "PatientsID", cascadeDelete: true);
            AddForeignKey("dbo.Visitations", "PatientsId", "dbo.Patients", "PatientsID", cascadeDelete: true);
            DropColumn("dbo.Diagnoses", "PatientId");
            DropColumn("dbo.Visitations", "PatientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Visitations", "PatientId", c => c.Int(nullable: false));
            AddColumn("dbo.Diagnoses", "PatientId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Visitations", "PatientsId", "dbo.Patients");
            DropForeignKey("dbo.Diagnoses", "PatientsId", "dbo.Patients");
            DropIndex("dbo.Visitations", new[] { "PatientsId" });
            DropIndex("dbo.Diagnoses", new[] { "PatientsId" });
            AlterColumn("dbo.Visitations", "PatientsId", c => c.Int());
            AlterColumn("dbo.Diagnoses", "PatientsId", c => c.Int());
            RenameColumn(table: "dbo.Visitations", name: "PatientsId", newName: "Patients_PatientsID");
            RenameColumn(table: "dbo.Diagnoses", name: "PatientsId", newName: "Patients_PatientsID");
            CreateIndex("dbo.Visitations", "Patients_PatientsID");
            CreateIndex("dbo.Diagnoses", "Patients_PatientsID");
            AddForeignKey("dbo.Visitations", "Patients_PatientsID", "dbo.Patients", "PatientsID");
            AddForeignKey("dbo.Diagnoses", "Patients_PatientsID", "dbo.Patients", "PatientsID");
        }
    }
}
