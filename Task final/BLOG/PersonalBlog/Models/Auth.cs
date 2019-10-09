using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalBlog.Models
{
    public static class Auth
    {
        public static bool IsAdmin(string login, string password)
        {
            return login == "admin" && password == "admin";
        }
    }
}