using CarManagementSystem.Data;
using CarManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarManagementSystem.Pages.Cars;

public class EditModel(CarDbContext context) : PageModel
{
    [BindProperty]
    public Car Car { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var car = await context.Cars.FindAsync(id);
        if (car is null)
            return NotFound();

        Car = car;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        if (!await context.Cars.AnyAsync(car => car.Id == Car.Id))
            return NotFound();

        context.Attach(Car).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
