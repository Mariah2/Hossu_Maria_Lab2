using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hossu_Maria_Lab2.Data;
using Hossu_Maria_Lab2.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Hossu_Maria_Lab2.Pages.Books
{
    [Authorize(Roles = "Admin")]
    public class EditModel : BookCategoriesPageModel
    {
        private readonly Hossu_Maria_Lab2Context _context;

        public EditModel(Hossu_Maria_Lab2Context context)
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

            PopulateAssignedCategoryData(_context, book);

            Book = book;

            ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id is null)
            {
                return NotFound();
            }
            //aici profa voastra se pisa pe restul chestiilor si facea rost de Book-ul din db dupa ID
            //adica orice alta proprietate in afara de categories era luata iar din db si ce ai modificat? iti arat imediat

            //e ceva stricat aici in UpdateBookCategories

            _context.Update(Book).State = EntityState.Modified;

            await UpdateBookCategories(_context, selectedCategories, Book.ID);

            await _context.SaveChangesAsync();

            PopulateAssignedCategoryData(_context, Book);

            return RedirectToPage("./Index");
        }
    }
}
