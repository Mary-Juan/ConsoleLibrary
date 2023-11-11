using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Exceptions
{
    internal class BorrowMoreThenThreeBooksException : Exception
    {
        public override string Message => "You can't borrow more than 3 books.";
    }
}
