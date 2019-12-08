using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CafeBook.Models;
using CafeBook.Repositories;
using CafeBook.Services;
using Moq;
using Xunit;

namespace CafeBookTests
{
    public class BookServiceTest
    {
        [Fact]
        public async Task AddTest()
        {
            var fake = Mock.Of<IBookRepository>();
            var bookService = new BookService(fake);

            var book = new Book() { BookName = "1984", Author = "Oruell", PublishedYear = "1984", Publisher = "asd", BookTypeId = 1 };
            await bookService.AddAndSave(book);
        }
        [Fact]
        public async Task UpdateTest()
        {
            var fake = Mock.Of<IBookRepository>();
            var bookService = new BookService(fake);

            var book = new Book() { BookName = "1982", Author = "Oruell00", PublishedYear = "1982", Publisher = "asd00", BookTypeId = 5 };
            await bookService.Update(book);
        }
        [Fact]
        public async Task RemoveTest()
        {
            var fake = Mock.Of<IBookRepository>();
            var bookService = new BookService(fake);
            var book = new Book() { BookName = "1983", Author = "Oruell0", PublishedYear = "1983", Publisher = "asd0", BookTypeId = 4 };
            await bookService.Delete(book);
        }
        [Fact]
        public async Task DetailTest()
        {
            var fake = Mock.Of<IBookRepository>();
            var bookService = new BookService(fake);
            var id = 2;
            await bookService.DetailsBook(id);
        }
        [Fact]
        public async Task GetBooksTest()
        {
            var books = new List<Book>
            {
                new Book() { BookName = "1985", Author = "Oruell1", PublishedYear = "1986", Publisher = "asd1", BookTypeId = 2  },
                new Book() { BookName = "1988", Author = "Oruell2", PublishedYear = "1986", Publisher = "asd2", BookTypeId = 3 },
        };

            var fakeRepositoryMock = new Mock<IBookRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(books);


            var bookService = new BookService(fakeRepositoryMock.Object);

            var resultBooks = await bookService.GetBook();

            Assert.Collection(resultBooks, book =>
            {
                Assert.Equal("1985", book.BookName);
                Assert.Equal("Oruell1", book.Author);
                Assert.Equal("1986", book.PublishedYear);
                Assert.Equal("asd1", book.Publisher);
                Assert.Equal(2, book.BookTypeId);
            },
            book =>
            {
                Assert.Equal("1988", book.BookName);
                Assert.Equal("Oruell2", book.Author);
                Assert.Equal("1986", book.PublishedYear);
                Assert.Equal("asd2", book.Publisher);
                Assert.Equal(3, book.BookTypeId);
            });
        }
    }
}
