using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.USERS_.Common
{
    interface IUI
    {
        void SelectOption();
        void AskUserAttributes(out String name, out DateTime birthDay, out uint age);
        void DeleteUser();
        void ShowAllUsers();

    }
}
