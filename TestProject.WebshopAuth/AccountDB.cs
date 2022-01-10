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
        List<User> allUsers = new List<User>();
        public AccountDB()
        {
            User u = new User();
            u.userId = 1;
            u.email = "a@a.nl";
            u.password = "a";
            u.city = "Tilburg";
            u.adress = "Piusstraat 150";
            u.firstName = "Billy";
            u.lastName = "Kuiper";
            u.addition = "5";
            u.zipcode = "5021JD";

            User u2 = new User();
            u2.userId = 2;
            u2.email = "b@b.nl";
            u2.password = "b";
            u2.city = "Bergen op Zoom";
            u2.adress = "Strandplevier 16";
            u2.firstName = "Meriam";
            u2.lastName = "Doe";
            u2.addition = "";
            u2.zipcode = "4617AZ";

            User u3 = new User();
            u3.userId = 3;
            u3.email = "c@c.nl";
            u3.password = "c";
            u3.city = "Tilburg";
            u3.adress = "Piusstraat 150";
            u3.firstName = "Jens";
            u3.lastName = "Doomen";
            u3.addition = "6";
            u3.zipcode = "5021JD";

            allUsers.Add(u);
            allUsers.Add(u2);
            allUsers.Add(u3);
        }

        public User checkRegistered(User user)
        {
            foreach(User u in allUsers)
            {
                if(u.email == user.email)
                {
                    return u;
                }
            }
            return null;
        }

        public User getUserById(string userId)
        {
            User returnUser = null;
            foreach(User u in allUsers)
            {
                if(u.userId == Convert.ToInt32(userId))
                {
                    returnUser = u;
                }
            }
            return returnUser;
        }

        public User login(User user)
        {
            foreach(User u in allUsers)
            {
                if(u.email == user.email)
                {
                    if(u.password == user.password)
                    {
                        return u;
                    }
                }
            }
            return null;
        }

        public bool register(User u)
        {
            try
            {
                allUsers.Add(u);
                if(allUsers.Count == 4)
                {
                    return true;
                }
               
                return false;
                
            }
            catch
            {
                return false;
            }
        }

        public bool updatePassword(string userId, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
