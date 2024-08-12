using LibraryApp.Core.Models;
using LibraryApp.Core.Repositories.Contracts;
using LibraryApp.Core.Services.Contracts;
using LibraryApp.Infrastructure.Services.Implementations;
using Moq;

namespace LibraryApp.Tests.Services
{
    [TestClass]
    public class BookServiceTests
    {
        protected Mock<ILibraryRepository>? _libraryRepositoryMock;
        private BookService? _bookService;

        [TestInitialize]
        public void Initialize()
        {
            _libraryRepositoryMock = new Mock<ILibraryRepository>();
            _bookService = new BookService(_libraryRepositoryMock.Object);
        }

        [TestMethod]
        public async Task GetAllAsync_CallsRepo()
        {
            if (_libraryRepositoryMock == null) throw new NullReferenceException();
            if (_bookService == null) throw new NullReferenceException();

            _libraryRepositoryMock.Setup(x => x.GetBooks())
                .Returns(new List<Book>());

            var result = await _bookService.GetAllAsync();

            _libraryRepositoryMock.Verify(x => x.GetBooks(), Times.Once);
        }

        [TestMethod]
        public async Task GetByIdAsync_CallsRepo()
        {
            if (_libraryRepositoryMock == null) throw new NullReferenceException();
            if (_bookService == null) throw new NullReferenceException();

            _libraryRepositoryMock.Setup(x => x.GetBooks())
                .Returns(new List<Book>() { new Book(){ Id = 1, Title="Test Book"}
                });

            var result = await _bookService.GetByIdAsync(1);

            _libraryRepositoryMock.Verify(x => x.GetBooks(), Times.Once);
        }

        [TestMethod]
        public async Task SaveAsync_CallsAddRepo()
        {
            if (_libraryRepositoryMock == null) throw new NullReferenceException();
            if (_bookService == null) throw new NullReferenceException();

            _libraryRepositoryMock.Setup(x => x.AddBook(new Book() { Id = 0 }));

            var result = await _bookService.SaveAsync(new Book() { Id = 0 });

            _libraryRepositoryMock.Verify(x => x.AddBook(It.IsAny<Book>()), Times.Once);
        }

        [TestMethod]
        public async Task SaveAsync_CallsUpdateRepo()
        {
            if (_libraryRepositoryMock == null) throw new NullReferenceException();
            if (_bookService == null) throw new NullReferenceException();

            _libraryRepositoryMock.Setup(x => x.UpdateBook(new Book() { Id = 1 }));

            var result = await _bookService.SaveAsync(new Book() { Id = 1 });

            _libraryRepositoryMock.Verify(x => x.UpdateBook(It.IsAny<Book>()), Times.Once);
        }
    }
}
