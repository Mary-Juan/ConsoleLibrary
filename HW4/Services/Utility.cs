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
        public Member? GetMemberById(long nationalCode)
        {
            foreach (Member member in Database.Database.Members)
            {
                if (member.NationalCode == nationalCode)
                {
                    return member;
                }
            }
            return null;
        }

        public Book? GetBookById(long id)
        {
            foreach (Book book in Database.Database.AllBooks)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }

        public long GetIdByEmail(string email)
        {
            foreach (Member member in Database.Database.Members)
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
