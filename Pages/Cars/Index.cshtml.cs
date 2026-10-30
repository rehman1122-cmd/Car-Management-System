using CarManagementSystem.Data;
using CarManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarManagementSystem.Pages.Cars;

public class IndexModel(CarDbContext context) : PageModel
{
    public IList<Car> Cars { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Cars = await context.Cars.OrderByDescending(car => car.AddedOn).ToListAsync();
    }
}
