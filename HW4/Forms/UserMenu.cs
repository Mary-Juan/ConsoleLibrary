using HW4.DTOs;
using HW4.Entities;
using HW4.Services;
using HW4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HW4.Forms
{
    internal class UserMenu
    {

        ILibraryService libraryService = new LibraryService();
        Utility utility = new Utility();

        public bool MemberMenu(long userId)
        {
            bool toContinue = false;
            Console.WriteLine("1.Borrow book \n 2.Return book \n 3.Borrowed Book list \n 4.Show all unborrowed books \n 5.Logout");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    {
                        Console.WriteLine("What genre of book do you want to borrow?");
                        int genre = 0;

                        while (true)
                        {
                            genre = GenresMenu();
                            if (genre != 0)
                                break;
                            Console.WriteLine("enter correct number of option!");
                        }

                        Book[] books = libraryService.GetBooksByGenres(genre);
                        foreach (Book book in books)
                        {
                            ShowBook(book);
                        }

                        Console.WriteLine("enter book id: ");
                        int bookId = int.Parse(Console.ReadLine());

                        if (libraryService.BorrowBook(bookId, userId))
                        {
                            Console.WriteLine("Borrowing was successful. enter 'b' to back to menu | enter 'e' to exit");
                        }
                        else
                            Console.WriteLine("Borrowing was unsuccessful. enter 'b' to back to menu | enter 'e' to exit");

                        string input = Console.ReadLine();

                        if (input == "b")
                        {
                            toContinue = true;
                        }

                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("enter book id: ");
                        int bookId = int.Parse(Console.ReadLine());

                        if (libraryService.ReturnBook(bookId, userId))
                            Console.WriteLine("Returning was successful. enter 'b' to back to menu | enter 'e' to exit");
                        else
                            Console.WriteLine("Returning was successful. enter 'b' to back to menu | enter 'e' to exit");

                        string input = Console.ReadLine();

                        if (input == "b")
                        {
                            toContinue = true;
                        }

                        break;
                    }

                case "3":
                    {
                        foreach (var book in libraryService.GetListOfUserBooks(userId))
                        {
                            ShowBook(book);
                            Console.WriteLine("-------------");
                        }

                        Console.WriteLine("enter 'b' to back to menu | enter 'e' to exit");

                        string input = Console.ReadLine();

                        if (input == "b")
                        {
                            toContinue = true;
                        }

                        break;
                    }

                case "4":
                    {
                        foreach (Book book in libraryService.GetListOfLibraryBooks())
                        {
                            ShowBook(book);
                        }

                        Console.WriteLine("enter 'b' to back to menu | enter 'e' to exit");
                        string input = Console.ReadLine();

                        if (input == "b")
                        {
                            toContinue = true;
                        }

                        break;
                    }
                case "5":
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("please enter a number between 1 to 5");
                        toContinue = true;
                        break;
                    }
            }
            return toContinue;
        }

        public int GenresMenu()
        {
            Console.WriteLine("1.Scientific\n2.Novel\n3.historical\n4.cooking");
            if (int.TryParse(Console.ReadLine(), out int option))
                return option;
            return 0;
        }

        public void ShowBook(Book book)
        {
            Console.WriteLine("Name: " + book.Name);
            Console.WriteLine("writer: " + book.Writer);
            Console.WriteLine("Date of Realese: " + book.DateOfRelease);
            Console.WriteLine("Id : " + book.Id);
            Console.WriteLine("-------------");
        }

        public bool LibraryManagerMenu(long userId)
        {
            bool toContinue = false;
            Console.WriteLine("1.Add Book \n 2.Delete Book \n 3.Show All Books \n 4.Show All Borrowed Books \n 5.Logout");
            string option = Console.ReadLine();

            switch(option)
            {
                case "1": {
                        Console.WriteLine("Enter the name of book:");
                        string bookName = Console.ReadLine();

                        Console.WriteLine("Enter the writer of book:");
                        string writerName = Console.ReadLine();

                        Console.WriteLine("What's the genre of the book?");

                        int genre = 0;

                        while (true)
                        {
                            genre = GenresMenu();
                            if (genre != 0)
                                break;
                            Console.WriteLine("enter correct number of option!");
                        }

                        BookDTO book = new BookDTO()
                        {
                            Name = bookName,
                            Writer = writerName,
                            Genre = genre
                        };

                        if(libraryService.AddBook(book))
                            Console.WriteLine("Adding book was successful");
                        else
                            Console.WriteLine("Adding book was not successful");

                        break; }
            }
        }
    }


}
