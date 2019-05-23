namespace ConsoleApp3.Data.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Hospital : DbContext
    {
        // Контекст настроен для использования строки подключения "Hospital" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "ConsoleApp3.Data.Model.Hospital" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Hospital" 
        // в файле конфигурации приложения.
        public Hospital()
            : base("name=Hospital")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Diagnoses> Diagnoses { get; set; }
        public virtual DbSet<Medicaments> Medicaments { get; set; }
        public virtual DbSet<PatientMedicament> PatientMedicament { get; set; }
        public virtual DbSet<Visitations> Visitations { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<DoctorPatient> DoctorPatient { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}