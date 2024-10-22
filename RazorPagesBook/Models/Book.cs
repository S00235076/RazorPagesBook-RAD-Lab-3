using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RazorPagesBook.Models
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 5)]
        [Required]
        public string? Title { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(100,MinimumLength = 50)]
        public string? Summary { get; set; }
        public string? Publication { get; set; }

        public int AuthorID { get; set; }
        public int PublisherID { get; set; }

        [Display(Name = "Publication Date")]
        [DataType(DataType.Date)]
        public DateTime DateOfPublication { get; set; }

        public string? CoverPage { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Rating { get; set; } = string.Empty;
    }
}
