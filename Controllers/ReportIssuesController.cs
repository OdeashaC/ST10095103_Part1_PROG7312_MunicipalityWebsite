using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10095103_Part1_PROG7312_MunicipalityWebsite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST10095103_Part1_PROG7312_MunicipalityWebsite.Controllers
{
    public class ReportIssuesController : Controller
    {
        private readonly MunicipalityDatabaseContext dbcontext;

        public ReportIssuesController(MunicipalityDatabaseContext _dbContext)
        {
            dbcontext = _dbContext;
        }

        public IActionResult ReportIssues()
        {
            return View();
        }

        public IActionResult ReportIssue()
        {
            // Retrieve categories from the database
            var categories = dbcontext.CategorySelections.ToList();

            // Create and populate the view model
            var viewModel = new ReportIssueViewModel
            {
                ReportIssue = new ReportIssue(), // Initialize if required
                Categories = categories // Ensure this is not null
            };

            // Pass the view model to the view
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ReportIssue(ReportIssueViewModel model, IFormFile media)
        {
            if (ModelState.IsValid)
            {
                // Save the file if needed
                if (media != null && media.Length > 0)
                {
                    var filePath = Path.Combine("wwwroot/uploads", media.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await media.CopyToAsync(stream);
                    }

                    model.ReportIssue.FilePath = filePath;
                    model.ReportIssue.FileType = media.ContentType;
                }

                // Save the issue to the database
                dbcontext.ReportIssues.Add(model.ReportIssue);
                await dbcontext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            // Reload categories and redisplay the form if validation fails
            model.Categories = dbcontext.CategorySelections.ToList();
            return View(model);
        }
    }
}
