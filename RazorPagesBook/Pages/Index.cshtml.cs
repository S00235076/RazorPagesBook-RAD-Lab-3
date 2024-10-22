using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesBook.Models;

namespace RazorPagesMovie.Pages.Movies;

public class IndexModel : PageModel
{
    private readonly RazorPagesBook.Data.RazorPagesBookContext _context;

    public IndexModel(RazorPagesBook.Data.RazorPagesBookContext context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    public SelectList? Genres { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? BookGenre { get; set; }


    public async Task OnGetAsync()
    {
        // Use LINQ to get list of genres.
        IQueryable<string> genreQuery = from m in _context.Book
                                        orderby m.Summary
                                        select m.Summary;

        var books = from m in _context.Book
                     select m;

        if (!string.IsNullOrEmpty(SearchString))
        {
            books = books.Where(s => s.Title.Contains(SearchString));
        }

        if (!string.IsNullOrEmpty(BookGenre))
        {
            books = books.Where(x => x.Summary == BookGenre);
        }
        Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
        Book = await books.ToListAsync();
    }
}