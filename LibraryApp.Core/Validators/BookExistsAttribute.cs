using LibraryApp.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.Validators
{
    public class BookExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var bookId = value != null ? (int)value : 0;
            var bookService = (IBookService)validationContext.GetService(typeof(IBookService));
            var book = bookService?.GetByIdAsync(bookId).Result;
            if (book == null)
            {
                return new ValidationResult($"Book with ID {bookId} does not exist.");
            }

            return ValidationResult.Success;
        }
    }
}
