using Microsoft.EntityFrameworkCore;
using SBA_BACKEND.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Speciality> Specialities{ get; set; }
        public DbSet<SpecialityTechnician> SpecialityTechnicians { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //ENTITIES

            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<District>().ToTable("Districts");
            builder.Entity<Opinion>().ToTable("Opinions");
            builder.Entity<Report>().ToTable("Reports");
            builder.Entity<Speciality>().ToTable("Specialities");
            builder.Entity<SpecialityTechnician>().ToTable("SpecialityTechnicians");
            builder.Entity<Technician>().ToTable("Technicians");
            builder.Entity<User>().ToTable("Users");

            //CONSTRAINTS

            //Constraints of User
            builder.Entity<User>().HasKey(user => user.Id); //Primary Key
            builder.Entity<User>().Property(user => user.Id).IsRequired().ValueGeneratedOnAdd(); //Auto Generate a Primary Key
            builder.Entity<User>().Property(user => user.Name).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(user => user.Email).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(user => user.Password).IsRequired().HasMaxLength(150);
            builder.Entity<User>().Property(user => user.Cellphone).IsRequired();

            //Constraints of Customer
            builder.Entity<Customer>().Property(customer => customer.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(customer => customer.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(customer => customer.Password).IsRequired().HasMaxLength(150);
            builder.Entity<Customer>().Property(customer => customer.Cellphone).IsRequired();

            //Constraints of Technician
            builder.Entity<Technician>().Property(technician => technician.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Technician>().Property(technician => technician.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Technician>().Property(technician => technician.Password).IsRequired().HasMaxLength(150);
            builder.Entity<Technician>().Property(technician => technician.Cellphone).IsRequired();
            builder.Entity<Technician>().Property(technician => technician.Description).HasMaxLength(300);

            //Constraints of District
            builder.Entity<District>().HasKey(district => district.Id); //Primary Key
            builder.Entity<District>().Property(district => district.Id).IsRequired().ValueGeneratedOnAdd(); //Auto Generate a Primary Key
            builder.Entity<District>().Property(district => district.Name).IsRequired().HasMaxLength(50);

            //Constraints of Opinion
            builder.Entity<Opinion>().HasKey(opinion => opinion.Id); //Primary Key
            builder.Entity<Opinion>().Property(opinion => opinion.Id).IsRequired().ValueGeneratedOnAdd(); //Auto Generate a Primary Key
            builder.Entity<Opinion>().Property(opinion => opinion.Stars).IsRequired();
            builder.Entity<Opinion>().Property(opinion => opinion.Description).IsRequired().HasMaxLength(300);

            //Constraints of Report
            builder.Entity<Report>().HasKey(report => report.Id); //Primary Key
            builder.Entity<Report>().Property(report => report.Id).IsRequired().ValueGeneratedOnAdd(); //Auto Generate a Primary Key
            builder.Entity<Report>().Property(report => report.Description).IsRequired().HasMaxLength(300);

            //Constraints of Speciality
            builder.Entity<Speciality>().HasKey(speciality => speciality.Id); //Primary Key
            builder.Entity<Speciality>().Property(speciality => speciality.Id).IsRequired().ValueGeneratedOnAdd(); //Auto Generate a Primary Key
            builder.Entity<Speciality>().Property(speciality => speciality.Name).IsRequired().HasMaxLength(30);

            //Constraints of SpecialityTechnician
            builder.Entity<SpecialityTechnician>().HasKey(st => new { st.SpecialityId, st.TechnicianId }); //Primary Key

            //RELATIONSHIPS

            //Relationships of User

            builder.Entity<User>() //One to Many with District
                .HasOne(user => user.District)
                .WithMany(district => district.Users)
                .HasForeignKey(user => user.DistrictId);

            //Relationships of Opinion

            builder.Entity<Opinion>() //One to Many with Customer
                .HasOne(opinion => opinion.Customer)
                .WithMany(customer => customer.Opinions)
                .HasForeignKey(opinion => opinion.CustomerId);

            builder.Entity<Opinion>() //One to Many with Technician
                .HasOne(opinion => opinion.Technician)
                .WithMany(technician => technician.Opinions)
                .HasForeignKey(opinion => opinion.TechnicianId);

            //Relationships of Report

            builder.Entity<Report>() //One to Many with Customer
                .HasOne(report => report.Customer)
                .WithMany(customer => customer.Reports)
                .HasForeignKey(report => report.CustomerId);

            builder.Entity<Report>() //One to Many with Technician
                .HasOne(report => report.Technician)
                .WithMany(technician => technician.Reports)
                .HasForeignKey(report => report.TechnicianId);

            //Relationships of SpecialityTechnician

            //Many to Many with Speciality and Technician
            builder.Entity<SpecialityTechnician>()
                .HasOne(st => st.Speciality)
                .WithMany(speciality => speciality.SpecialityTechnicians)
                .HasForeignKey(st => st.SpecialityId);
            builder.Entity<SpecialityTechnician>()
                .HasOne(st => st.Technician)
                .WithMany(technician => technician.SpecialityTechnicians)
                .HasForeignKey(st => st.TechnicianId);

            //SEED DATA UDS LO PONEN >:V
            //no
        }
    }
}
