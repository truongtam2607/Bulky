using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public Category? Category{ get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public void Onget(int? id)
        {
           if(id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
            
            
           
        }


        public IActionResult Onpost()
        {
            if (ModelState.IsValid)
            {
                if (Category.Id == null)
                {
                    TempData["error"] = "This ID is null. Reload page please!";
                    return RedirectToPage("Index");

                }
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully!";
            }
            return RedirectToPage("Index");
            
        }
    }
}
