using Microsoft.EntityFrameworkCore;
using Hossu_Maria_Lab2.Models;

namespace Hossu_Maria_Lab2.Data
{
    public class Hossu_Maria_Lab2Context : DbContext
    {
        public Hossu_Maria_Lab2Context (DbContextOptions<Hossu_Maria_Lab2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; } = null!;

        public virtual DbSet<Publisher> Publisher { get; set; } = null!;

        public virtual DbSet<Author> Author { get; set; } = null!;

        public virtual DbSet<Category> Category { get; set; } = null!;

        public DbSet<Hossu_Maria_Lab2.Models.Member> Member { get; set; }

        public DbSet<Hossu_Maria_Lab2.Models.Borrowing> Borrowing { get; set; }
    }
}
