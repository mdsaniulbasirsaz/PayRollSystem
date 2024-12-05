using Microsoft.EntityFrameworkCore;
using PayRollSystem.Models;

namespace PayRollSystem.Data
{
	public class PayRollContext : DbContext
	{
		// Constructor
		public PayRollContext(DbContextOptions<PayRollContext> options)
			: base(options)
		{
		}

		// DbSet for Employees
		public DbSet<Employee> Employees { get; set; }

		// Configurations (optional)
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Configuring Employee table
			modelBuilder.Entity<Employee>(entity =>
			{
				entity.HasKey(e => e.EmployeeId); // Set primary key
				entity.Property(e => e.FirstName)
					  .IsRequired()
					  .HasMaxLength(50); // FirstName is required with max length 50
				entity.Property(e => e.LastName)
					  .IsRequired()
					  .HasMaxLength(50); // LastName is required with max length 50
				entity.Property(e => e.Position)
					  .HasMaxLength(50); // Position can have a max length of 50
				entity.Property(e => e.Salary)
					  .HasColumnType("decimal(18,2)"); // Define Salary type
			});
		}
	}
}
