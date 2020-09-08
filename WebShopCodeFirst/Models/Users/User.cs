using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopCodeFirst.Models.Users
{
    public class User
    {
        #region Fields and Properties
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int AddressId { get; set; }
        public string Telephone { get; set; }
        public bool IsActive { get; set; }
        public Role Role { get; set; }
        public Address Address { get; set; }
        #endregion

        #region Constructor
        public User()
        {

        }

        public User(int userId, string firstName, string lastName, int age, int roleId, string username, string email, string password, int addressId, string telephone, bool isActive)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            RoleId = roleId;
            Username = username;
            Email = email;
            Password = password;
            AddressId = addressId;
            Telephone = telephone;
            IsActive = isActive;
        }
        #endregion

        #region Methods

        //public void PrintUser()
        //{
        //    Console.WriteLine($"ID: {UserId}, Name: {FirstName}, Userame: {Username}, Email: {Email}, Age: {Age}");
        //    Console.WriteLine($"-------------------------");
        //}
        #endregion
    }
}