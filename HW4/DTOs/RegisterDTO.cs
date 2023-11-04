using HW4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.DTOs
{
    internal class RegisterDTO
    {
        public long NationalCode { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Education { get; set; }
        public int Role { get; set; }
    }
}
