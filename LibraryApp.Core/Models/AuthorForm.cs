using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Core.Models
{
    public class AuthorForm
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
    }
}
