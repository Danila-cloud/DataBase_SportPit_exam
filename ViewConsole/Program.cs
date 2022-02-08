using System;
using ViewConsole.Views;

namespace ViewConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Views.User u = new User();
            u.Register();
        }
    }
}
