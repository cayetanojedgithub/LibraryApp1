using LibraryApp.Core.Validators;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Core.Models
{
    public class BookForm
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        [AuthorExists]
        public int AuthorId { get; set; }
    }
}
