using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Exeptions
{
    internal class BookReservedExeption : Exception
    {
        public override string Message => "the book has borrowed, so you can't Delete it.";
    }
}
