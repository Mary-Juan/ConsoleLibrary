using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Entities
{
    internal class Member : Person
    {

        public DateTime RegisterDate { get; set; }
       public Book[] BorrowedBook = new Book[0];
        public DateTime CreditBalance { get; set; }
        public int PecuniaryDamages { get; set; }
    }
}
