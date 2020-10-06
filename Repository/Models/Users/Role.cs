using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models.Users
{
    public class Role
    {
        #region Fields and Properties
        private IGenericRepository<Role> _repository;
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public List<Action> RoleActions { get; set; }
        #endregion

        #region Constructor

        public Role()
        {
            this._repository = new GenericRepositort<Role>();

        }

        public Role(IGenericRepository<Role> _repository)
        {
            this._repository = _repository;
        }

        public Role(string roleName, string roleDescreption, List<Action> actions)
        {
            this.RoleName = roleName;
            this.RoleDescription = roleDescreption;
            this.RoleActions = actions;
        }
        #endregion

        #region Method
        //public void AddActionToRole(Action action)
        //{
        //    RoleActions.Add(action);
        //}

        //public void AddActionsToRole(List<Action> actions)
        //{
        //    RoleActions = actions;
        //}

        //public void CheckIfActionExist(Action action)
        //{
        //    if (RoleActions.Contains(action))
        //    {
        //        action.PrintAction();
        //    }
        //}

        public IEnumerable<Role> GetAllRoles()
        {
            return _repository.GetAll();
        }
        #endregion
    }
}