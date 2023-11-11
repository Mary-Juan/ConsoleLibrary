using HW4.DTOs;
using HW4.Entities;
using HW4.Exceptions;
using HW4.Services.Interfaces;
using HW4.storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static HW4.Entities.Book;

namespace HW4.Services
{
    internal  class LibraryService : ILibraryService
    {
        private string _filePath;
        Book[] allBooks;
        private Serialization<Book> _serialization;

        public LibraryService(string filePath)
        {
         _filePath = filePath;
            _serialization = new Serialization<Book>();
          allBooks = _serialization.DeserializeFromJsonFile(filePath);
            
        }

        Utility utility = new Utility();


        public bool BorrowBook(int bookId, long userId)
        {
            
            try
            {
                Member member = utility.GetMemberById(userId);
                Book book = utility.GetBookById(bookId);
                if (member.BorrowedBook.Length > 2)
                    throw new BorrowMoreThenThreeBooksException();

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
            catch(BorrowMoreThenThreeBooksException ex)
            {
                Console.WriteLine(ex.Message); return false;
            }
            catch
            {
                return false;
            }
        }

        public Book[] GetBooksByGenres(int genre)
        {
            Genre booksGenre = (Genre)genre;
            return allBooks.Where(b => b.Genres == booksGenre).ToArray();
        }

        public Book[] GetListOfUnBorrowedBooks()
        {
            return allBooks.Where(b => b.IsBorrowed == false).ToArray();
        }

        public Book[] GetListOfLibraryBooks()
        {
            return allBooks.ToArray();
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

        public void SaveChanges()
        {
            _serialization.SerializeToJsonFile(_filePath, allBooks);
        }
    }
}
