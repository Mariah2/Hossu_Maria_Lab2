using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hossu_Maria_Lab2.Data;
using Hossu_Maria_Lab2.Models;

namespace Hossu_Maria_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Hossu_Maria_Lab2Context _context;

        public IndexModel(Hossu_Maria_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;
        public BookData BookData { get; set; } = null!;
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookData = new BookData
            {
                Books = await _context.Book
                    .Include(b => b.Author)
                    .Include(b => b.Publisher)
                    .Include(b => b.BookCategories)
                    .ThenInclude(b => b.Category)
                    .AsNoTracking()
                    .OrderBy(b => b.Title)
                    .ToListAsync()
            };

            if (id is not null)
            {
                BookID = id.Value;

                if (BookData.Books.SingleOrDefault(i => i.ID == id.Value) is Book book)
                {
                    BookData.Categories = book.BookCategories.Select(s => s.Category);
                }
            }
        }
    }
}
