using Microsoft.EntityFrameworkCore;
using RazorPagesBook.Data;
namespace RazorPagesBook.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesBookContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesBookContext>>()))
            {
                if (context == null || context.Book == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "When Harry Met Sally",
                        DateOfPublication = DateTime.Parse("1989-2-12"),
                        Summary = "Romantic Comedy",
                        AuthorID = 4,
                        Rating = "R"
                    },

                    new Book
                    {
                        Title = "Ghostbusters ",
                        DateOfPublication = DateTime.Parse("1984-3-13"),
                        Summary = "Comedy",
                        AuthorID = 2,
                        Rating = "PG"
                    },

                    new Book
                    {
                        Title = "Ghostbusters 2",
                        DateOfPublication = DateTime.Parse("1986-2-23"),
                        Summary = "Comedy",
                        AuthorID = 2,
                        Rating = "PG"
                    },

                    new Book
                    {
                        Title = "Rio Bravo",
                        DateOfPublication = DateTime.Parse("1959-4-15"),
                        Summary = "Western",
                        AuthorID = 2,
                        Rating = "U"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
