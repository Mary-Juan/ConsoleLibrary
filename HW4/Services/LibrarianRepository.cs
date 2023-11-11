using HW4.DTOs;
using HW4.Entities;
using HW4.Exeptions;
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
    internal class LibrarianRepository : ILibrarianRepository
    {
        private string _filePath;
        Book[] allBooks;
        private Serialization<Book> _serialization;
        public LibrarianRepository(string filePath)
        {
            _filePath = filePath;
            _serialization = new Serialization<Book>();
            allBooks = _serialization.DeserializeFromJsonFile(filePath);
        }
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

                allBooks = Database.Database.AllBooks.Append(book).ToArray();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBook(int id)
        {
            try
            {
                Book book = GetBookById(id);
                if (book.IsBorrowed)
                    throw new BookReservedExeption();
                Database.Database.AllBooks = Database.Database.AllBooks.Where(b => b != book).ToArray();
                return true;
            }
            catch(BookReservedExeption ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch { return false; }

        }

        public Book GetBookById(int id)
        {
            return Database.Database.AllBooks.Where(b => b.Id == id).SingleOrDefault();
        }
    }
}
