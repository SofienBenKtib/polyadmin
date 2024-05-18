using BackofficePfa.Data;
using BackofficePfa.Models;
using BackofficePfa.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackofficePfa.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public InstructorController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddInstructorViewModel viewModel)
        {
            var instructor = new Instructor
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subject = viewModel.Subject,
                NightClasses = viewModel.NightClasses,
            };
            await dbContext.Instructors.AddAsync(instructor);
            await dbContext.SaveChangesAsync();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var instructors = await dbContext.Instructors.ToListAsync();
            return View(instructors);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var instructor = await dbContext.Instructors.FindAsync(id);
            return View(instructor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Instructor viewModel)
        {
            var instructor = await dbContext.Instructors.FindAsync(viewModel.Id);
            if (instructor is not null)
            {
                instructor.Name = viewModel.Name;
                instructor.Email = viewModel.Email;
                instructor.Phone = viewModel.Phone;
                instructor.Subject = viewModel.Subject;
                instructor.NightClasses = viewModel.NightClasses;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Instructor");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Instructor viewModel)
        {
            var instructor = await dbContext.Instructors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (instructor is not null)
            {
                dbContext.Instructors.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Instructor");
        }
    }
}