using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrudRazorProject.Data;
using CrudRazorProject.Models;

namespace CrudRazorProject.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly CrudRazorProject.Data.ApplicationDbContext _context;

        public IndexModel(CrudRazorProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
