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
    public class DetailsModel : PageModel
    {
        private readonly JobTrackerWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(JobTrackerWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Job Job { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Job == null)
            {
                return NotFound();
            }

            var job = await _context.Job.FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }
            else 
            {
                Job = job;
            }
            return Page();
        }
    }
}
