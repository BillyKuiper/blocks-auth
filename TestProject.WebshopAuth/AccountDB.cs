using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAuth.Models;
using WebshopAuth.Services;

namespace TestProject.WebshopAuth
{
    public class AccountDB : IAccount
    {
        public User checkRegistered(User u)
        {
            throw new NotImplementedException();
        }

        public User getUserById(string userId)
        {
            throw new NotImplementedException();
        }

        public User login(User u)
        {
            throw new NotImplementedException();
        }

        public string loginNoToken(int id, int role)
        {
            throw new NotImplementedException();
        }

        public bool register(User u)
        {
            throw new NotImplementedException();
        }
    }
}
