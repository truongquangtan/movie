using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Pages_Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;
        
        public IndexModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]
        public string searchString {get; set;}
        public SelectList Genres {get; set;}
        [BindProperty(SupportsGet = true)]
        public string MovieGenre {get; set;}

        public async Task OnGetAsync()
        {
            var movies = from m in _context.Movie select m;
            
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
