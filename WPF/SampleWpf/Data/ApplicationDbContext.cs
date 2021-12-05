using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWpf.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            // no migrations required
            // Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.Default.GetConnectionString("DefaultConnection"));
            }
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }

    public class Company
    {
        public Company()
        {
            Employees = new List<Employee>();
        }

        [Key]
        public int CompanyId { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }

        public List<Employee> Employees { get; set; }
    }

    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Title { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company? Company { get; set; }
    }
}
