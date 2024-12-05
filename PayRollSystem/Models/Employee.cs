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
	}
}
