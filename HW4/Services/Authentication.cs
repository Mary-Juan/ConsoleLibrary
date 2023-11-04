using HW4.Database;
using HW4.DTOs;
using HW4.Entities;
using HW4.Services.Interfaces;
using HW4.storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Services
{
    internal class Authentication : IAuthentication
    {
       

        public bool Login(LoginDTO login)
        {
            foreach (Person member in Database.Database.Members)
            {
                if (member.Email == login.Email && member.Password == login.Password)
                {
                    return true;
                }
            }
            foreach (Person employee in Database.Database.LibraryManagers)
            {
                if (employee.Email == login.Email && employee.Password == login.Password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool RegisterEmployee(RegisterDTO register)
        {
            try
            {
                Role role = new Role()
                {
                    RoleId = register.Role,
                    RoleTitle = "Library Manager"
                };

                libraryManager employee = new libraryManager()
                {
                    NationalCode = register.NationalCode,
                    FullName = register.FullName,
                    Email = register.Email,
                    Password = register.Password,
                    Age = register.Age,
                    Education = register.Education,
                    Role = role,
                    HoursOfWork = 8,
                    PersonalId = AutoEncrementValues.PersonalId++
                };

                Database.Database.LibraryManagers= Database.Database.LibraryManagers.Append(employee).ToArray();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool RegisterMember(RegisterDTO register)
        {
            try
            {

                Role role = new Role()
                {
                    RoleId = register.Role,
                    RoleTitle = "Member"
                };

                Member member = new Member()
                {
                    NationalCode = register.NationalCode,
                    FullName = register.FullName,
                    Email = register.Email,
                    Password = register.Password,
                    Age = register.Age,
                    Education = register.Education,
                    Role = role,
                    BorrowedBook = new Book[0] ,
                    CreditBalance = DateTime.Now.AddYears(1),
                    PecuniaryDamages = 0,
                    RegisterDate = DateTime.Now
                };

                Database.Database.LibraryManagers = Database.Database.LibraryManagers.Append(member).ToArray();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
