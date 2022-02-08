using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ClassLibrary.Exceptions.InputData;
using ClassLibrary.Helpers.Checked;

namespace ClassLibrary.Entities.Auth
{
    public class User : Base
    {
        /// <summary>
        /// Проверяет. может ли пользователь выполнить данную операцию
        /// </summary>
        /// <param name="AcceptGroup"> Группы, которым разрешены операции</param>
        /// <returns>true - если может</returns>
        public bool isUserCan(List<Group> AcceptGroup)
        {
            if (AcceptGroup == null) return true;

            foreach (Group group in AcceptGroup)
            {
                if (Groups.Contains(group)) { return true; }
            }
            return false;
        }

        public List<Group> Groups { get; set; } = new List<Group>();

        [XmlIgnore]
        [JsonIgnore]
        private string _email;

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (InputData.CheckEmail(value))
                {
                    _email = value;
                    return;
                }
                throw new ExceptionInputDataEmail();
            }
        }

        public bool isEmailVerificated { get; set; } = false;
        public string Phone { get; set; }
        public bool isPhoneVerificated { get; set; } = false;


        /// <summary>
        /// Добавить шифрование SHA256
        /// </summary>
        public string Password { get; set; }

    }
}
