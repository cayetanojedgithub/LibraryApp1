using LibraryApp.Core.Models;
using LibraryApp.Infrastructure.Repositories.Implementations;

namespace LibraryApp.Tests.Repositories
{
    [TestClass]
    public class LibraryRepositoryTests
    {
        [TestMethod]
        public void ReturnsAuthors()
        {
            var repo = new LibraryRepository();

            Assert.IsTrue(repo.GetAuthors() != null);
            Assert.IsTrue(repo.GetAuthors().Count > 0);
        }

        [TestMethod]
        public void ReturnsBooks()
        {
            var repo = new LibraryRepository();

            Assert.IsTrue(repo.GetBooks() != null);
            Assert.IsTrue(repo.GetBooks().Count > 0);
        }

        [TestMethod]
        public void AddAuthor_IsSuccessful()
        {
            var repo = new LibraryRepository();

            var newAuthorCount = repo.GetAuthors().Count + 1;
            repo.AddAuthor(new Author() { Id = newAuthorCount, FirstName = $"John{newAuthorCount}", LastName = $"Doe{newAuthorCount}" });

            Assert.IsTrue(repo.GetAuthors().Count == newAuthorCount);
        }

        [TestMethod]
        public void AddBook_IsSuccessful()
        {
            var repo = new LibraryRepository();

            var newBookCount = repo.GetBooks().Count + 1;
            repo.AddBook(new Book() { Id = newBookCount, Title = $"New Book {newBookCount}" });

            Assert.IsTrue(repo.GetBooks().Count == newBookCount);
        }

        [TestMethod]
        public void UpdateAuthor_IsSuccessful()
        {
            var repo = new LibraryRepository();

            var existingAuthor = repo.GetAuthors().First(x => x.Id == 1);
            existingAuthor.FirstName = "Modified FirstName";
            existingAuthor.LastName = "Modified LastName";
            repo.UpdateAuthor(existingAuthor);

            Assert.IsTrue(repo.GetAuthors().First(x => x.Id == 1).FirstName == "Modified FirstName");
            Assert.IsTrue(repo.GetAuthors().First(x => x.Id == 1).LastName == "Modified LastName");
        }

        [TestMethod]
        public void UpdateBook_IsSuccessful()
        {
            var repo = new LibraryRepository();

            var existingBook = repo.GetBooks().First(x => x.Id == 1);
            existingBook.Title = "Modified Title";
            repo.UpdateBook(existingBook);

            Assert.IsTrue(repo.GetBooks().First(x => x.Id == 1).Title == "Modified Title");
        }
    }
}
