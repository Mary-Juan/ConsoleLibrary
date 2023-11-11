using HW4.DTOs;
using HW4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Services.Interfaces
{
    internal interface ILibrarianRepository
    {
        public bool AddBook(BookDTO bookDto);
        public bool DeleteBook(int id);
        public Book GetBookById(int id);
    }
}
