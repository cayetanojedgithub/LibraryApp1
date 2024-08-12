using LibraryApp.Core.Models;

namespace LibraryApp.Core.Repositories.Contracts
{
    public interface ILibraryRepository
    {
        IList<Author> GetAuthors();
        IList<Book> GetBooks();
        void AddAuthor(Author author);
        void AddBook(Book book);
        void UpdateAuthor(Author entity);
        void UpdateBook(Book book);
    }
}
