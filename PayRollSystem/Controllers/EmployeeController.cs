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
		// GET: Employee/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			var employee = await _context.Employees.FindAsync(id);
			if (employee == null)
			{
				return NotFound();
			}
			return View(employee);
		}

		// POST: Employee/Edit/5 (Handles regular POST request)
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Employee employee)
		{
			if (ModelState.IsValid)
			{
				_context.Update(employee);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index)); // After edit, redirect to employee list
			}
			return View(employee);
		}

		// POST: Employee/Edit (AJAX endpoint for modal)
		[HttpPost]
		public async Task<IActionResult> EditEmployee(Employee employee)
		{
			if (ModelState.IsValid)
			{
				// Update the employee record in the database
				_context.Update(employee);
				await _context.SaveChangesAsync();

				// Return success response in JSON format
				return Json(new { success = true, message = "Employee updated successfully!" });
			}

			// Return error response in case of failure
			return Json(new { success = false, message = "There was an error updating the employee." });
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
