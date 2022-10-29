using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hossu_Maria_Lab2.Data;
using Hossu_Maria_Lab2.Models;

namespace Hossu_Maria_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Hossu_Maria_Lab2Context _context;

        public DetailsModel(Hossu_Maria_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (book is null)
            {
                return NotFound();
            }
            
            Book = book;

            return Page();
        }
    }
}
