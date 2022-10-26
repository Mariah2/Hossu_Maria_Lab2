using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hossu_Maria_Lab2.Data;
using Hossu_Maria_Lab2.Models;

namespace Hossu_Maria_Lab2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Hossu_Maria_Lab2.Data.Hossu_Maria_Lab2Context _context;

        public IndexModel(Hossu_Maria_Lab2.Data.Hossu_Maria_Lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Author != null)
            {
                Author = await _context.Author.ToListAsync();
            }
        }
    }
}
