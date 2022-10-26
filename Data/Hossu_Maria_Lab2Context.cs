using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<Hossu_Maria_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Hossu_Maria_Lab2.Models.Publisher> Publisher { get; set; }

        public DbSet<Hossu_Maria_Lab2.Models.Author> Author { get; set; }

        public DbSet<Hossu_Maria_Lab2.Models.Category> Category { get; set; }
    }
}
