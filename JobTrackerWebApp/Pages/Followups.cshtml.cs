using JobTrackerWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;



namespace JobTrackerWebApp.Pages
{
    public class FollowupsModel : PageModel
    {
        private readonly JobTrackerWebApp.Data.ApplicationDbContext _context;

        public FollowupsModel(JobTrackerWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        //public void OnGet()
        //{
        //}

        //public IActionResult OnGet()
        //{
        //    return Page();
        //}

        [BindProperty]
        public Follow Follow { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Follow == null || Follow == null)
            {
                return Page();
            }

            _context.Follow.Add(Follow);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        //public Follow Follow { get; set; } = default!;

        public IList<Follow> FollowList { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Follow != null)
            {
                FollowList = await _context.Follow.ToListAsync();
            }
        }

        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null || _context.Follow == null)
        //    {
        //        return NotFound();
        //    }

        //    var follow = await _context.Follow.FirstOrDefaultAsync(m => m.Id == id);
        //    if (Follow == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        Follow = Follow;
        //    }
        //    return Page();
        //}


    }
}

