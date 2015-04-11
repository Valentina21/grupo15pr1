using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public abstract class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("NAME")]
        public String Name { get; set; }
        [Column("START_DATE")]
        public DateTime StartDate { get; set; }
       
    }

    public class InheritanceMappingContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FullTimeEmployee>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("FULL_TIME_EMP");
            });

            modelBuilder.Entity<PartTimeEmployee>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("PART_TIME_EMP");
            });
        }
    }
}
