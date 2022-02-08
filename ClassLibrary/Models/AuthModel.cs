using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ClassLibrary.Entities.Auth;
using ClassLibrary.Exceptions.Models;

namespace ClassLibrary.Models
{
    public class AuthModel : IModel
    {
        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public User CurentUser { get; set; }

        public List<User> Users { get; set; } = new List<User>();
        public List<Group> Groups { get; set; } = new List<Group>();



        private static AuthModel _instanse;

        private AuthModel()
        {
            try
            {
                Load();
            }
            catch (Exception e)
            {
                Seed();
                CurentUser = Users.First(u => u.Name == "guest");
                FileName = "auth";
            }
        }
        public static AuthModel GetInstanse() => _instanse ??= new AuthModel();


        public void Seed()
        {
            // Супер администратор
            Group gRoot = new Group() { Name = "root" };
            User uRoot = new User() { Name = "root"};
            uRoot.Groups.Add(gRoot);
            Users.Add(uRoot);
            Groups.Add(gRoot);

            // Для обычного пользователя
            Group gGuest = new Group() { Name = "guest" };
            User uGuest = new User() { Name = "guest" };
            uGuest.Groups.Add(gGuest);
            Users.Add(uGuest);
            Groups.Add(gGuest);
        }


        public string FileName { get; set; }

        public void Load()
        {
            XmlSerializer formatterUser = new XmlSerializer(typeof(List<User>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".users.xml", FileMode.Open))
                {
                    Users = (List<User>)formatterUser.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                throw new ExceptionModelsFile();
            }

            XmlSerializer formatterGroup = new XmlSerializer(typeof(List<Group>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".groups.xml", FileMode.Open))
                {
                    Groups = (List<Group>)formatterGroup.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                throw new ExceptionModelsFile();
            }



        }

        public void Save()
        {
            XmlSerializer formatterUser = new XmlSerializer(typeof(List<User>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".users.xml" , FileMode.OpenOrCreate))
                {
                    formatterUser.Serialize(fs, Users);
                }

            }
            catch (Exception e)
            {
                throw new ExceptionModelsFile();
            }

            XmlSerializer formatterGroup = new XmlSerializer(typeof(List<Group>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".groups.xml", FileMode.OpenOrCreate))
                {
                    formatterGroup.Serialize(fs, Groups);
                }

            }
            catch (Exception e)
            {
                throw new ExceptionModelsFile();
            }
        }
    }
}
