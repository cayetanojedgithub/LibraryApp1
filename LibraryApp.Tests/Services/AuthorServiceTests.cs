using LibraryApp.Core.Models;
using LibraryApp.Core.Repositories.Contracts;
using LibraryApp.Infrastructure.Services.Implementations;
using Moq;

namespace LibraryApp.Tests.Services
{
    [TestClass]
    public class AuthorServiceTests
    {
        protected Mock<ILibraryRepository>? _libraryRepositoryMock;
        private AuthorService? _authorService;

        [TestInitialize]
        public void Initialize()
        {
            _libraryRepositoryMock = new Mock<ILibraryRepository>();
            _authorService = new AuthorService(_libraryRepositoryMock.Object);
        }

        [TestMethod]
        public async Task GetAllAsync_CallsRepo()
        {
            if (_libraryRepositoryMock == null) throw new NullReferenceException();
            if (_authorService == null) throw new NullReferenceException();

            _libraryRepositoryMock.Setup(x => x.GetAuthors())
                .Returns(new List<Author>());

            var result = await _authorService.GetAllAsync();

            _libraryRepositoryMock.Verify(x => x.GetAuthors(), Times.Once);
        }

        [TestMethod]
        public async Task GetByIdAsync_CallsRepo()
        {
            if (_libraryRepositoryMock == null) throw new NullReferenceException();
            if (_authorService == null) throw new NullReferenceException();

            _libraryRepositoryMock.Setup(x => x.GetAuthors())
                .Returns(new List<Author>() { new Author(){ Id = 1, FirstName="First", LastName="Last"}
                });

            var result = await _authorService.GetByIdAsync(1);

            _libraryRepositoryMock.Verify(x => x.GetAuthors(), Times.Once);
        }

        [TestMethod]
        public async Task SaveAsync_CallsAddRepo()
        {
            if (_libraryRepositoryMock == null) throw new NullReferenceException();
            if (_authorService == null) throw new NullReferenceException();

            _libraryRepositoryMock.Setup(x => x.AddAuthor(new Author() { Id = 0 }));

            var result = await _authorService.SaveAsync(new Author() { Id = 0 });

            _libraryRepositoryMock.Verify(x => x.AddAuthor(It.IsAny<Author>()), Times.Once);
        }

        [TestMethod]
        public async Task SaveAsync_CallsUpdateRepo()
        {
            if (_libraryRepositoryMock == null) throw new NullReferenceException();
            if (_authorService == null) throw new NullReferenceException();

            _libraryRepositoryMock.Setup(x => x.UpdateAuthor(new Author() { Id = 1 }));

            var result = await _authorService.SaveAsync(new Author() { Id = 1 });

            _libraryRepositoryMock.Verify(x => x.UpdateAuthor(It.IsAny<Author>()), Times.Once);
        }
    }
}
