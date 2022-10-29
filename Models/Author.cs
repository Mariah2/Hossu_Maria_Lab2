using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hossu_Maria_Lab2.Models
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int ID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!; 
        [NotMapped]
        [Display(Name = "Author")]
        public string FullName => FirstName + " " + LastName;

        public ICollection<Book> Books { get; set; }
    }
}
