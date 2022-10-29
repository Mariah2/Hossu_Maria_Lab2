namespace Hossu_Maria_Lab2.Models
{
    public class BookCategory
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public virtual Book Book { get; set; } = null!;
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; } = null!;
    }
}
