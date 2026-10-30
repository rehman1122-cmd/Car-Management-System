using CarManagementSystem.Data;
using CarManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarManagementSystem.Pages.Cars;

public class DeleteModel(CarDbContext context) : PageModel
{
    [BindProperty]
    public Car Car { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var car = await context.Cars.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);
        if (car is null)
            return NotFound();

        Car = car;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var car = await context.Cars.FindAsync(Car.Id);
        if (car is null)
            return NotFound();

        context.Cars.Remove(car);
        await context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
