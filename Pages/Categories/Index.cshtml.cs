using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Borsan_Alexandra_Lab2.Data;
using Borsan_Alexandra_Lab2.Models;
using System.Security.Cryptography.X509Certificates;
using Borsan_Alexandra_Lab2.Models;

namespace Borsan_Alexandra_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Borsan_Alexandra_Lab2.Data.Borsan_Alexandra_Lab2Context _context;

        public IndexModel(Borsan_Alexandra_Lab2.Data.Borsan_Alexandra_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public BookData BookD { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            BookD = new BookData();
            BookD.Categories = await _context.Category
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Book)
                .OrderBy(b => b.CategoryName)
                .ToListAsync();
            BookD.BookCategories = await _context.BookCategory
                .Include(b => b.Category)
                .Include(b => b.Book)
                .OrderBy(b => b.Book)
                .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                BookD.Books = await _context.BookCategory
                .Where(bc => bc.CategoryID == CategoryID)
                .Select(bc => bc.Book)
                .ToListAsync();
            }
        }
    }
}