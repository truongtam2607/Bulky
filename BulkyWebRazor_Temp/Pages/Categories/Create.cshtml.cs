using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
         
        }
        public IActionResult OnPost()
        {
            bool check = false;
            foreach (var category in _db.Categories)
            {
                if (Category.DisplayOrder == category.DisplayOrder)
                    check = true;
            }
            if (check != true)
            {
                _db.Categories.Add(Category);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully!";
                return RedirectToPage("Index");
            }
            else
            {
                TempData["error"] = "Error! Display Order be created.";
                return RedirectToPage("Index");
            }
            
        }
    }
}
