using System;
using System.Collections.Generic;
using ClassLibrary.Entities.Auth;
using ClassLibrary.Models;

namespace ClassLibrary.Controllers.Auth
{
    public class GroupController : IController<Group>
    {
        private AuthModel _model;
        public GroupController()
        {
            _model = AuthModel.GetInstanse();
            AcceptGroup = new List<Group>();
            AcceptGroup.Add(_model.Groups.FindLast(g=> g.Name=="root"));
        }

        public List<Group> AcceptGroup { get; set; }
        public bool Create(Group Item)
        {
            if (_model.CurentUser.isUserCan(AcceptGroup))
            {
                _model.Groups.Add(Item);
                return true;
            }

            return false;
        }

        public Group Read(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<Group> ReadAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid Id, Group Item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}