using BLOG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalBlog.Models
{
    public static class Auth
    {
        
        public static bool Admin = false;
        public static User LoggedUser = null;
        public static bool visitor = true;
        public static bool CheckUser(string login, string password)
        {
            EntityWithBlogManager entity = new EntityWithBlogManager();
            IList<User> users = entity.GetAllUsers();

            foreach (User user in users)
            {
                if (user.Login == login && user.Password == password)
                {
                    if (user.Id == 1) { // В БД администратор имеет ID = 1
                        Admin = true;
                    }
                    LoggedUser = user;
                    visitor = false;
                    return true;
                }
            }
            return false;
        }
    }
}