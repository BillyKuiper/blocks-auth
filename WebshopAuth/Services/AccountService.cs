using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAuth.Data;
using WebshopAuth.Models;

namespace WebshopAuth.Services
{
    public class AccountService : IAccount
    {
        private readonly DataContext dc;

        public AccountService(DataContext dc)
        {
            this.dc = dc;
        }

        public User getUserById(string userId)
        {
            return dc.Users.Where(x => x.userId == Convert.ToInt32(userId)).FirstOrDefault();
        }

        public User login(User u)
        {
            return dc.Users.Where(x => x.email.Equals(u.email) && x.password.Equals(u.password)).FirstOrDefault();
        }

        public User checkRegistered(User u)
        {
            try
            {
                return dc.Users.Where(x => x.email.Equals(u.email)).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool register(User u)
        {
            try
            {
                dc.Users.Add(u);
                dc.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
