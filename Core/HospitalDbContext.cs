using Microsoft.EntityFrameworkCore;
using NewLab_2.Models;
using System.Configuration;

namespace NewLab_2.Core
{
    public class HospitalDbContext : DbContext
    {
        #region PROPERTIES

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityType> CityTypes { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<EducationPlace> EducationPlaces { get; set; }
        public DbSet<EducationPlacePhone> EducationPlacePhones { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HouseNumber> HousesNumber { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientEducationPlace> PatientEducationPlaces { get; set; }
        public DbSet<PatientWorkplace> PatientWorkplaces { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Rhesus> Rhesuses { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<WorkplacePhone> WorkplacePhones { get; set; }

        #endregion

        public HospitalDbContext()
        {
        }

        #region METHODS

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().ToTable("addresses");
            modelBuilder.Entity<BloodGroup>().ToTable("blood_groups");
            modelBuilder.Entity<City>().ToTable("cities");
            modelBuilder.Entity<CityType>().ToTable("city_types");
            modelBuilder.Entity<Diagnosis>().ToTable("diagnoses");
            modelBuilder.Entity<Disease>().ToTable("diseases");
            modelBuilder.Entity<EducationPlace>().ToTable("education_places");
            modelBuilder.Entity<EducationPlacePhone>().ToTable("education_place_phones");
            modelBuilder.Entity<Employee>().ToTable("employees");
            modelBuilder.Entity<HouseNumber>().ToTable("houses_number");
            modelBuilder.Entity<MedicalHistory>().ToTable("medical_history");
            modelBuilder.Entity<Patient>().ToTable("patients");
            modelBuilder.Entity<PatientEducationPlace>().ToTable("patient_education_places");
            modelBuilder.Entity<PatientWorkplace>().ToTable("patient_workplaces");
            modelBuilder.Entity<Person>().ToTable("persons");
            modelBuilder.Entity<Region>().ToTable("regions");
            modelBuilder.Entity<Rhesus>().ToTable("rhesuses");
            modelBuilder.Entity<Speciality>().ToTable("specialties");
            modelBuilder.Entity<Street>().ToTable("streets");
            modelBuilder.Entity<Visit>().ToTable("visits");
            modelBuilder.Entity<Workplace>().ToTable("workplaces");
            modelBuilder.Entity<WorkplacePhone>().ToTable("workplace_phones");

            modelBuilder.Entity<PatientEducationPlace>().HasNoKey();
            modelBuilder.Entity<PatientWorkplace>().HasNoKey();
            
            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        }

        #endregion
    }
}