using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary.Controllers.Auth;
using ClassLibrary.Models;
using System.Threading.Tasks;

using static System.Console;


namespace ViewConsole.Views
{
    class User
    {
        private UserController controller;

        public User()
        {
            controller = new UserController();
        }


        public void Login()
        {

        }

        public void Register()
        {
            ClassLibrary.Entities.Auth.User newUser =  new ClassLibrary.Entities.Auth.User();

            Write("Введите имя: ");
            newUser.Name = ReadLine();

            bool isCorrect = true;
            do
            {
                try
                {
                    Write("Введите email: ");
                    isCorrect = true;
                    newUser.Email = ReadLine();
                }
                catch (Exception e)
                {
                    WriteLine(" Ошибка при вводе email");
                    isCorrect = false;
                }
            } while (!isCorrect);

            newUser.Groups.Add( AuthModel.GetInstanse().Groups.FindLast(g=>g.Name == "guest"));

            controller.Create(newUser);
            AuthModel.GetInstanse().Save();

        }

    }
}
