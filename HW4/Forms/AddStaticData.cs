using HW4.Database;
using HW4.DTOs;
using HW4.Entities;
using HW4.Forms;
using HW4.Services;
using HW4.Services.Interfaces;

namespace HW4.Forms
{
    internal class AddStaticData
    {
        Book book1 = new Book()
        {
            Name = "folan",
            Writer = "folani",
            DateOfRelease = new DateTime(),
            Id = 1,
            IsBorrowed = false

        };

        Book book2 = new Book()
        {
            Name = "bisan",
            Writer = "bolani",
            DateOfRelease = new DateTime(),
            Id = 2,
            IsBorrowed = false
        };

        Book book3 = new Book()
        {
            Name = "bahman",
            Writer = "bahmani",
            DateOfRelease = new DateTime(),
            Id = 3,
            IsBorrowed = false
        };

 
    }
}
