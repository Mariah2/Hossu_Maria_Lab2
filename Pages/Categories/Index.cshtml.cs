using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hossu_Maria_Lab2.Data;
using Hossu_Maria_Lab2.Models;
using Hossu_Maria_Lab2.Models.ViewModels;

namespace Hossu_Maria_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Hossu_Maria_Lab2Context _context;

        public IndexModel(Hossu_Maria_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public Book BookData { get; set; } = default!;
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData
            {
                Categories = await _context.Category
                .Include(i => i.BookCategories)
                .ThenInclude(c => c.Book)
                .ThenInclude(c => c.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync()
            };

            if (id is not null)
            {
                CategoryID = id.Value;

                Category category = CategoryData.Categories.Where(i => i.ID == id.Value).Single();

                CategoryData.BookCategories = category.BookCategories;
            }
        }
    }
}
