using LibraryApp.Core.Services.Contracts;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Core.Validators
{
    public class AuthorExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var authorId = value != null ? (int)value : 0;
            var authorService = (IAuthorService)validationContext.GetService(typeof(IAuthorService));
            var author = authorService?.GetByIdAsync(authorId).Result;
            if (author == null)
            {
                return new ValidationResult($"Author with ID {authorId} does not exist.");
            }

            return ValidationResult.Success;
        }
    }
}
