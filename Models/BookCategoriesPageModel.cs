using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hossu_Maria_Lab2.Data;

namespace Hossu_Maria_Lab2.Models
{
    public class BookCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList = null!;

        public void PopulateAssignedCategoryData(Hossu_Maria_Lab2Context context, Book book)
        {
            var allCategories = context.Category;

            var bookCategories = new HashSet<int>(book.BookCategories.Select(c => c.CategoryID));

            AssignedCategoryDataList = new List<AssignedCategoryData>();

            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = bookCategories.Contains(cat.ID)
                });
            }
        }
        public async Task UpdateBookCategories(Hossu_Maria_Lab2Context context, string[] selectedCategories, int bookId)
        {
            var bookCategories = await context.Set<BookCategory>().Where(bc => bc.BookID == bookId).ToListAsync();

            if (selectedCategories is null)
            {
                foreach (var bookCategory in bookCategories)
                {
                    context.Set<BookCategory>().Remove(bookCategory).State = EntityState.Deleted;
                }

                return;
            }

            var categoriesToDelete = bookCategories.Where(bc => !selectedCategories.Contains(bc.CategoryID.ToString()));

            foreach (var bookCategory in categoriesToDelete)
            {
                context.Set<BookCategory>().Remove(bookCategory).State = EntityState.Deleted;
            }

            foreach (var categoryId in selectedCategories)
            {
                int parsedCategoryId = int.Parse(categoryId);

                if (bookCategories.Find(b => b.CategoryID == parsedCategoryId) is null)
                {
                    context.Set<BookCategory>().Add(new BookCategory
                    {
                        BookID = bookId,
                        CategoryID = parsedCategoryId
                    }).State = EntityState.Added;
                }
            }
        }
    }
}
