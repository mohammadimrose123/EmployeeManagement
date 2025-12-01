
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers {
 public class EmployeeController : Controller {
  private readonly AppDbContext _db;
  public EmployeeController(AppDbContext db){_db=db;}

  public async Task<IActionResult> Index()=>View(await _db.Employees.ToListAsync());
  public IActionResult Create()=>View();
  [HttpPost] public async Task<IActionResult> Create(Employee emp){
    if(ModelState.IsValid){_db.Employees.Add(emp);await _db.SaveChangesAsync();return RedirectToAction("Index");}
    return View(emp);
  }
  public async Task<IActionResult> Edit(int id)=>View(await _db.Employees.FindAsync(id));
  [HttpPost] public async Task<IActionResult> Edit(Employee emp){_db.Employees.Update(emp);await _db.SaveChangesAsync();return RedirectToAction("Index");}
  public async Task<IActionResult> Delete(int id)=>View(await _db.Employees.FindAsync(id));
  [HttpPost,ActionName("Delete")] public async Task<IActionResult> DeleteConfirmed(int id){
    var emp=await _db.Employees.FindAsync(id);_db.Employees.Remove(emp);await _db.SaveChangesAsync();return RedirectToAction("Index");
  }
 }
}
