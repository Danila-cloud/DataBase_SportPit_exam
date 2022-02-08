using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Entities.Auth;
using ClassLibrary.Models;

namespace ClassLibrary.Controllers.Auth
{
    public class UserController : IController<User>
    {
        private AuthModel _model;
        public UserController()
        {
            _model = AuthModel.GetInstanse();
            AcceptGroup = new List<Group>();
            AcceptGroup.Add(_model.Groups.FindLast(g => g.Name == "guest"));
            AcceptGroup.Add(_model.Groups.FindLast(g => g.Name == "root"));
        }

        public List<Group> AcceptGroup { get; set; }
        public bool Create(User Item)
        {
            _model.Users.Add(Item);
            return true;
        }

        public User Read(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<User> ReadAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid Id, User Item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
