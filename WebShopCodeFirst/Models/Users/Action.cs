using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopCodeFirst.Models.Users
{
    public class Action
    {
        //Dodati u bazu i ovu klasu!!!

        /// TODO: add url
        #region Fields and Properties
        public int ActionId { get; set; }
        public string ActionName { get; set; }
        public string ActionDescription { get; set; }
        #endregion

        #region Constructors
        public Action()
        {

        }
        public Action(string actionName, string actionDescription)
        {
            this.ActionName = actionName;
            this.ActionDescription = actionDescription;
        }
        #endregion

        #region Methods
        public void PrintAction()
        {
            //Console.WriteLine($"ID: {ActionId}, Name: {ActionName}, Description: {ActionDescription}");
        }
        #endregion
    }
}