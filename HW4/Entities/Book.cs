using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Entities
{
    internal class Book
    {

       public enum Genre
        {
            Scientific = 1,
            Novel,
            historical,
            cooking
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Writer { get; set; }
        public bool IsBorrowed { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public DateTime? BorrowedDate { get; set; }
        public Genre Genres { get; set; }

    }
}
