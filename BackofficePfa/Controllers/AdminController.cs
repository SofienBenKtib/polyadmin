using BackofficePfa.Data;
using BackofficePfa.Models;
using BackofficePfa.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackofficePfa.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public AdminController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddAdminViewModel viewModel)
        {
            var admin = new Administrator
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Role = viewModel.Role,
            };
            await dbContext.Administrators.AddAsync(admin);
            await dbContext.SaveChangesAsync();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var admins = await dbContext.Administrators.ToListAsync();
            return View(admins);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var admins = await dbContext.Administrators.FindAsync(id);
            return View(admins);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Administrator viewModel)
        {
            var admin = await dbContext.Administrators.FindAsync(viewModel.Id);
            if (admin is not null)
            {
                admin.Name = viewModel.Name;
                admin.Email = viewModel.Email;
                admin.Phone = viewModel.Phone;
                admin.Role = viewModel.Role;
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Administrator viewModel)
        {
            var admin = await dbContext.Administrators.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (admin is not null)
            {
                dbContext.Administrators.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Admin");
        }
    }
}
