using System;
using System.ComponentModel.DataAnnotations;

namespace PayRollSystem.Models
{
	public class Employee
	{
		[Key]
		public int EmployeeId { get; set; }

		[Required]
		[StringLength(50)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(50)]
		public string LastName { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }

		[Required]
		[StringLength(50)]
		public string Position { get; set; }

		[Required]
		[Range(0, double.MaxValue)]
		public decimal Salary { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime DateOfJoining { get; set; }

		[Required]
		[Phone]
		[StringLength(15)]
		public string MobileNumber { get; set; } // Added MobileNumber

		[Required]
		[StringLength(200)]
		public string Address { get; set; } // Added Address

		[Required]
		[Range(0, double.MaxValue)]
		public decimal HourlyRate { get; set; } // Added HourlyRate
	}
}
