using HW4.DTOs;
using HW4.Entities;
using HW4.Services.Interfaces;
using HW4.storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HW4.Entities.Book;

namespace HW4.Services
{
    internal  class LibraryService : ILibraryService
    {

        Utility utility = new Utility();

        public bool AddBook(BookDTO bookDto)
        {
            try
            {
                Book book = new Book()
                {
                    Id = AutoEncrementValues.BookId++,
                    Name = bookDto.Name,
                    Writer = bookDto.Writer,
                    Genres = (Genre)bookDto.Genre,
                    BorrowedDate = null,
                    IsBorrowed = false,
                    DateOfRelease = null
                };

                Database.Database.AllBooks = Database.Database.AllBooks.Append(book).ToArray();
            }
            catch
            {
                return false;
            }
        }

        public bool BorrowBook(int bookId, long userId)
        {
            try
            {
                Member member = utility.GetMemberById(userId);
                Book book = utility.GetBookById(bookId);

                if (member != null && book != null)
                {
                    book.IsBorrowed = true;
                    book.BorrowedDate = DateTime.Now;
                    member.BorrowedBook = member.BorrowedBook.Append(book).ToArray();
                    book.IsBorrowed = true;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public Book[] GetBooksByGenres(int genre)
        {
            Genre booksGenre = (Genre)genre;
            return Database.Database.AllBooks.Where(b => b.Genres == booksGenre).ToArray();
        }

        public Book[] GetListOfLibraryBooks()
        {
            return Database.Database.AllBooks.Where(b => b.IsBorrowed == false).ToArray();
        }

        public Book[] GetListOfUserBooks(long id)
        {
            Member member = utility.GetMemberById(id);
            return member.BorrowedBook;
        }

        public bool ReturnBook(int bookId, long userId)
        {
            try
            {
                Member member = utility.GetMemberById(userId);
                Book book = utility.GetBookById(bookId);

                if (member != null && book != null)
                {
                    book.IsBorrowed = false;
                    book.BorrowedDate = null;
                    member.BorrowedBook = member.BorrowedBook.Where(b => b != book).ToArray();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
