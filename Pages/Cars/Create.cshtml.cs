using CarManagementSystem.Data;
using CarManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarManagementSystem.Pages.Cars;

public class CreateModel(CarDbContext context) : PageModel
{
    [BindProperty]
    public Car Car { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        Car.AddedOn = DateTime.UtcNow;
        context.Cars.Add(Car);
        await context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
