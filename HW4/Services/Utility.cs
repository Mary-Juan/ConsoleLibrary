using HW4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Services
{
    internal class Utility
    {
       
        public Member? GetMemberById(long nationalCode, Member[] members)
        {
            foreach (Member member in members)
            {
                if (member.NationalCode == nationalCode)
                {
                    return member;
                }
            }
            return null;
        }

        public Book? GetBookById(long id, Book[] books)
        {
            foreach (Book book in books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }

        public long GetIdByEmail(string email, Member[] members)
        {
            foreach (Member member in members)
            {
                if (member.Email == email)
                {
                    return member.NationalCode;
                }
            }
            return 0;
        }
    }
}
