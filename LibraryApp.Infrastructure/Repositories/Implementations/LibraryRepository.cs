using LibraryApp.Core.Models;
using LibraryApp.Core.Repositories.Contracts;

namespace LibraryApp.Infrastructure.Repositories.Implementations
{
    public sealed class LibraryRepository : ILibraryRepository
    {
        private List<Author> Authors { get; set; } = default!;
        private List<Book> Books { get; set; } = default!;
        public LibraryRepository()
        {
            Authors = new List<Author>() {
                new Author() { Id = 1, FirstName = "Morgan", LastName = "Housel" }
                ,new Author() { Id = 2, FirstName = "Mark", LastName = "Manson" }
                ,new Author() { Id = 3, FirstName = "James", LastName = "Clear" }
                ,new Author() { Id = 4, FirstName = "Robert", LastName = "Kiyoskai" }
                ,new Author() { Id = 5, FirstName = "Stephen", LastName = "Covey" }
            };

            Books = new List<Book>() {
                new Book() { Id = 1, Title = "The Psychology of Money", AuthorId = 1}
                , new Book() { Id = 2, Title = "The Subtle Art of Not Giving a F*ck", AuthorId = 2}
                , new Book() { Id = 3, Title = "Everthing is F*cked", AuthorId = 2}
                , new Book() { Id = 4, Title = "Atomic Habits", AuthorId = 3}
                , new Book() { Id = 5, Title = "Rich Dad Poor Dad", AuthorId = 4}
                , new Book() { Id = 6, Title = "7 Habits of Highly Effective People", AuthorId = 5}
            };
        }


        public void AddAuthor(Author author)
        {
            author.Id = Books.Select(x => x.Id).Max() + 1;
            Authors.Add(author);
        }

        public void AddBook(Book book)
        {
            book.Id = Books.Select(x => x.Id).Max() + 1;
            Books.Add(book);
        }

        public IList<Author> GetAuthors()
        {
            return Authors;
        }

        public IList<Book> GetBooks()
        {
            return Books;
        }

        public void UpdateAuthor(Author author)
        {
            var existingAuthor = Authors.Find(x => x.Id == author.Id);

            if (existingAuthor == null) {
                throw new Exception($"No author with id:{author.Id} exists.");
            }

            existingAuthor.FirstName = author.FirstName;
            existingAuthor.LastName = author.LastName;
        }

        public void UpdateBook(Book book)
        {
            var existingBook = Books.Find(x => x.Id == book.Id);

            if (existingBook == null)
            {
                throw new Exception($"No book with id:{book.Id} exists.");
            }

            existingBook.Title = book.Title;
        }
    }
}
