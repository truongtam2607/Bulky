using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.Completion;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public DeleteModel (ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                TempData["error"] = "This ID is null. Reload page please!";
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            Category = categoryFromDb;
            if(Category == null)
            {
                TempData["error"] = "This Category is null. Reload page please!";
                return NotFound();
            }
            return Page();

        }
        
        public IActionResult Onpost()
        {
            if(Category == null)
            {
                TempData["error"] = "This ID is null. Reload page please!";
                return NotFound();
            }
            else
            {
                _db.Categories.Remove(Category);
                _db.SaveChanges();
                TempData["success"] = "Category deleted successfully !";
                return RedirectToPage("Index");
            }
            
        }
    }
}
