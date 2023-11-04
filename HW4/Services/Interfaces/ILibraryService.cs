using HW4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Services.Interfaces
{
    internal interface ILibraryService
    {
        public bool BorrowBook(int bookId, long userId);
        public bool ReturnBook(int bookId, long userId);
        public Book[] GetListOfLibraryBooks();
        public Book[] GetListOfUserBooks(long id);
        public Book[] GetBooksByGenres(string genre);
    }
}
