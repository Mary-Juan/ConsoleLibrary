using HW4.DTOs;
using HW4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Services.Interfaces
{
    internal interface IAuthentication
    {
        public bool Login(LoginDTO login);
        public bool RegisterMember(RegisterDTO register);
        public bool RegisterEmployee(RegisterDTO register);
    }
}
