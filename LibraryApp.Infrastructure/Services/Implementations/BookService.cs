using LibraryApp.Core.Models;
using LibraryApp.Core.Repositories.Contracts;
using LibraryApp.Core.Services.Contracts;

namespace LibraryApp.Infrastructure.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly ILibraryRepository _library;
        public BookService(ILibraryRepository libraryRepository)
        {
            _library = libraryRepository;
        }

        public Task<List<Book>> GetAllAsync()
        {
            return Task.Run(() => {
                return _library.GetBooks().ToList();
            });
        }

        public Task<Book?> GetByIdAsync(int id)
        {
            return Task.Run(() => {
                return _library.GetBooks().FirstOrDefault(x => x.Id == id) ?? null;
            });
        }

        public Task<bool> SaveAsync(Book book)
        {
            return Task.Run(() => {
                try
                {
                    if (book.Id == 0)
                    {
                        _library.AddBook(book);
                    }
                    else
                    {
                        _library.UpdateBook(book);
                    }
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            });
        }
    }
}
