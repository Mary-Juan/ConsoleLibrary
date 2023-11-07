using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HW4.Entities.Book;

namespace HW4.DTOs
{
    internal class BookDTO
    {
        public string Name { get; set; }
        public string Writer { get; set; }
        public int Genre { get; set; }
    }
}
