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
        public DbSet<SpecialityTechnical> SpecialityTechnicals { get; set; }
        public DbSet<Technical> Technicals { get; set; }
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
            builder.Entity<SpecialityTechnical>().ToTable("SpecialityTechnicals");
            builder.Entity<Technical>().ToTable("Technicals");
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

            //Constraints of Technical
            builder.Entity<Technical>().Property(technical => technical.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Technical>().Property(technical => technical.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Technical>().Property(technical => technical.Password).IsRequired().HasMaxLength(150);
            builder.Entity<Technical>().Property(technical => technical.Cellphone).IsRequired();
            builder.Entity<Technical>().Property(technical => technical.Description).HasMaxLength(300);

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

            //Constraints of SpecialityTechnical
            builder.Entity<SpecialityTechnical>().HasKey(st => new { st.SpecialityId, st.TechnicalId }); //Primary Key

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

            builder.Entity<Opinion>() //One to Many with Technical
                .HasOne(opinion => opinion.Technical)
                .WithMany(technical => technical.Opinions)
                .HasForeignKey(opinion => opinion.TechnicalId);

            //Relationships of Report

            builder.Entity<Report>() //One to Many with Customer
                .HasOne(report => report.Customer)
                .WithMany(customer => customer.Reports)
                .HasForeignKey(report => report.CustomerId);

            builder.Entity<Report>() //One to Many with Technical
                .HasOne(report => report.Technical)
                .WithMany(technical => technical.Reports)
                .HasForeignKey(report => report.TechnicalId);

            //Relationships of SpecialityTechnical

            //Many to Many with Speciality and Technical
            builder.Entity<SpecialityTechnical>()
                .HasOne(st => st.Speciality)
                .WithMany(speciality => speciality.SpecialityTechnicals)
                .HasForeignKey(st => st.SpecialityId);
            builder.Entity<SpecialityTechnical>()
                .HasOne(st => st.Technical)
                .WithMany(technical => technical.SpecialityTechnicals)
                .HasForeignKey(st => st.TechnicalId);

            //SEED DATA UDS LO PONEN >:V
        }
    }
}
