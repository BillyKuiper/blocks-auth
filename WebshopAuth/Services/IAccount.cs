using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAuth.Models;

namespace WebshopAuth.Services
{
    public interface IAccount
    {
        public User login(User u);
        public string loginNoToken(int id, int role);
        public User checkRegistered(User u);
        public bool register(User u);
        public User getUserById(string userId);
    }
}
