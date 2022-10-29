namespace Hossu_Maria_Lab2.Models
{
    public class BookData
    {
        public BookData()
        {
            Books = new HashSet<Book>();
            Categories = new HashSet<Category>();
            BookCategories = new HashSet<BookCategory>();
        }

        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<BookCategory> BookCategories { get; set; }

    }

}
