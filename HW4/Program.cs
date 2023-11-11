using HW4.Database;
using HW4.DTOs;
using HW4.Entities;
using HW4.Forms;
using HW4.Services;
using HW4.Services.Interfaces;

Book book1 = new Book()
{
    Name = "folan",
    Writer = "folani",
    DateOfRelease = new DateTime(),
    Id = 1,
    IsBorrowed = false,
    Genres = Book.Genre.cooking

};

Book book2 = new Book()
{
    Name = "bisan",
    Writer = "bolani",
    DateOfRelease = new DateTime(),
    Id = 2,
    IsBorrowed = false,
    Genres = Book.Genre.Novel
};

Book book3 = new Book()
{
    Name = "bahman",
    Writer = "bahmani",
    DateOfRelease = new DateTime(),
    Id = 3,
    IsBorrowed = false,
    Genres = Book.Genre.Scientific
};

Role role = new Role()
{
    RoleId = 1,
    RoleTitle = "member"
};

Member user = new Member()
{
    NationalCode = 22,
    Age = 1,
    PecuniaryDamages = 1,
    RegisterDate = DateTime.Now,
    CreditBalance = DateTime.Now,
    Education = "jhf",
    Email = "w",
    Password = "w",
    FullName = "hyf",
    Role = role
};

Role role2 = new Role()
{
    RoleId = 2,
    RoleTitle = "manager"
};

Member user2 = new Member()
{
    NationalCode = 22,
    Age = 1,
    PecuniaryDamages = 1,
    RegisterDate = DateTime.Now,
    CreditBalance = DateTime.Now,
    Education = "jhf",
    Email = "ww",
    Password = "ww",
    FullName = "hyf",
    Role = role2
};


Database.AllBooks = Database.AllBooks.Append(book1).ToArray();
Database.AllBooks = Database.AllBooks.Append(book2).ToArray();
Database.AllBooks = Database.AllBooks.Append(book3).ToArray();

Database.Members = Database.Members.Append(user).ToArray();
Database.Members = Database.Members.Append(user2).ToArray();

IAuthentication authentication = new Authentication();
Utility utility = new Utility();
UserMenu userMenu = new UserMenu();

while (true)
{ 
    Console.WriteLine("Welcome to library. eneter '1' to login | enter '2' to register");
string loginOrRegister = Console.ReadLine();

    switch (loginOrRegister)
    {
        case "1":
            {
                LoginDTO login = AuthenticationForms.LoginForm();
                if (authentication.Login(login))
                {
                    Console.WriteLine("----------welcome--------");
                    long memberId = utility.GetIdByEmail(login.Email);
                    while (userMenu.MemberMenu(memberId))
                    {

                    }

                }
                else
                    Console.WriteLine("Not Found");
                break;
            }
        case "2":
            {
                RegisterDTO register = AuthenticationForms.RegisterForm();
               if(register.Role == 0)
                {
                    if (authentication.RegisterEmployee(register))
                    {
                        Console.WriteLine("please login");
                    }
                }
               else if(register.Role == 1)
                {
                    if (authentication.RegisterMember(register))
                    {
                        Console.WriteLine("please login");
                    }
                }

                break;
            }
        default: { break; }
    }

}