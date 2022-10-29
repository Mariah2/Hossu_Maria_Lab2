using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hossu_Maria_Lab2.Data;
using Hossu_Maria_Lab2.Models;

namespace Hossu_Maria_Lab2.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly Hossu_Maria_Lab2Context _context;

        public DeleteModel(Hossu_Maria_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var book = await _context.Book.SingleOrDefaultAsync(b => b.ID == id);

            if (book is null)
            {
                return NotFound();
            }

            Book = book;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);

            if (book is not null)
            {
                Book = book;

                _context.Book.Remove(Book);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
