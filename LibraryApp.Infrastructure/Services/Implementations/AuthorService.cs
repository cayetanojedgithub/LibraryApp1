using LibraryApp.Core.Models;
using LibraryApp.Core.Repositories.Contracts;
using LibraryApp.Core.Services.Contracts;

namespace LibraryApp.Infrastructure.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly ILibraryRepository _library;
        
        public AuthorService(ILibraryRepository libraryRepository)
        {
            _library = libraryRepository;
        }
        public Task<List<Author>> GetAllAsync()
        {
            return Task.Run(() => {
                return _library.GetAuthors().ToList();
            });
        }

        public Task<Author?> GetByIdAsync(int id)
        {
            return Task.Run(() => {
                return _library.GetAuthors().FirstOrDefault(x => x.Id == id) ?? null;
            });
        }

        public Task<bool> SaveAsync(Author entity)
        {
            return Task.Run(() => {
                try
                {
                    if (entity.Id == 0)
                    {
                        _library.AddAuthor(entity);
                    }
                    else
                    {
                        _library.UpdateAuthor(entity);
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
