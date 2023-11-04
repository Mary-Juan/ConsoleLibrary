using HW4.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Forms
{
    internal static class AuthenticationForms
    {
        public static LoginDTO LoginForm()
        {
            Console.WriteLine("enter your email:");
            string email = Console.ReadLine();

            Console.WriteLine("enter your password:");
            string password = Console.ReadLine();

            LoginDTO login = new LoginDTO()
            {
                Email = email,
                Password = password
            };

            return login;
        }

        public static RegisterDTO RegisterForm()
        {
            Console.WriteLine("enter your National Code:");
            long nationalCode = long.Parse(Console.ReadLine());

            Console.WriteLine("enter your FullName:");
            string fullName = Console.ReadLine();

            Console.WriteLine("enter your email:");
            string email = Console.ReadLine();

            Console.WriteLine("enter your password:");
            string password = Console.ReadLine();

            Console.WriteLine("enter your age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("enter your Aducation:");
            string aducation = Console.ReadLine();
                Console.WriteLine("enter your role:(enter '1' if u want to be a member | enter '2' if u want to be a library manager)");
            int role = int.Parse(Console.ReadLine());


            RegisterDTO register = new RegisterDTO()
            {
                NationalCode = nationalCode,
                FullName = fullName,
                Email = email,
                Password = password,
                Age = age,
                Education = aducation,
                Role = role
            };

            return register;

        }
    }
    
    
}
