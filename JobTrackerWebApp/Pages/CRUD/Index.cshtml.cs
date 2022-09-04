using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobTrackerWebApp.Data;

namespace JobTrackerWebApp.Pages.CRUD
{
    public class IndexModel : PageModel
    {
        private readonly JobTrackerWebApp.Data.ApplicationDbContext _context;

        public IndexModel(JobTrackerWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Job> Job { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Job != null)
            {
                Job = await _context.Job.ToListAsync();
            }
        }
    }
}
