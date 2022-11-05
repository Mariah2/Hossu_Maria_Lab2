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

        public IList<Book> Book { get; set; } = default!;
        public BookData BookData { get; set; } = null!;
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            AuthorSort = String.IsNullOrEmpty(sortOrder) ? "author_desc" : "";

            CurrentFilter = searchString;

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

            if (!String.IsNullOrEmpty(searchString))
            {
                BookData.Books = BookData.Books.Where(s => s.Author.FirstName.Contains(searchString)

               || s.Author.LastName.Contains(searchString)
               || s.Title.Contains(searchString));
            }

            if (id is not null)
            {
                BookID = id.Value;

                if (BookData.Books.SingleOrDefault(i => i.ID == id.Value) is Book book)
                {
                    BookData.Categories = book.BookCategories.Select(s => s.Category);
                }
            }

            switch (sortOrder)
            {
                case "title_desc":
                    BookData.Books = BookData.Books.OrderByDescending(s =>
                   s.Title);
                    break;
                case "author_desc":
                    BookData.Books = BookData.Books.OrderByDescending(s =>
                   s.Author.FullName);
                    break;

            }
        }
    }
}
