using Microsoft.AspNetCore.Mvc;
using PayRollSystem.Data;
using PayRollSystem.Models;
using System.Linq;

namespace PayRollSystem.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly PayRollContext _context;

		public EmployeeController(PayRollContext context)
		{
			_context = context;
		}

		// GET: Employee/Index
		public IActionResult Index()
		{
			var employees = _context.Employees.OrderByDescending(e => e.EmployeeId).ToList();
			return View(employees);
		}
		// GET: Employee/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Employee/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Employee employee)
		{
			if (ModelState.IsValid)
			{
				_context.Add(employee);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index)); // Redirects to Employee list view
			}
			return View(employee);
		}
		// GET: Employee/Edit/{id}
		public IActionResult Edit(int id)
		{
			var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
			if (employee == null)
			{
				return NotFound();
			}

			return View(employee);  // Display the edit page with employee details
		}

		// POST: Employee/Edit/{id}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("EmployeeId, FirstName, LastName, Position, Salary, DateOfJoining")] Employee employee)
		{
			if (id != employee.EmployeeId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(employee);
					_context.SaveChanges();
				}
				catch
				{
					return View(employee); // Handle exceptions appropriately
				}
				return RedirectToAction(nameof(Index));  // After saving, redirect back to the list page
			}
			return View(employee);  // Return to the edit page if validation fails
		}

		// GET: Employee/Delete/{id}
		public IActionResult Delete(int id)
		{
			var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
			if (employee == null)
			{
				return NotFound();
			}

			return View(employee);
		}

		// POST: Employee/Delete/{id}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var employee = _context.Employees.Find(id);
			if (employee != null)
			{
				_context.Employees.Remove(employee);
				_context.SaveChanges();
			}
			return RedirectToAction(nameof(Index));  // After deletion, redirect back to the list page
		}

	}
}
