using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models.Users
{
    public class User
    {
        #region Fields and Properties
        private IGenericRepository<User> _repository;

        public int UserId { get; set; }
        [Required(ErrorMessage = "This Field is Required!")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "This Field is Required!")]
        public string LastName { get; set; }

        public int Age { get; set; }

        public int RoleId { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        [DisplayName("User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "This Field is Required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int AddressId { get; set; }
        [Required(ErrorMessage = "This Field is Required!")]

        public string Telephone { get; set; }
        public bool IsActive { get; set; }
        public Role Role { get; set; }
        public Address Address { get; set; }

        //public string ErrorLoginMessage { get; set; }
        #endregion

        #region Constructor

        public User()
        {
            this._repository = new GenericRepositort<User>();

        }

        public User(IGenericRepository<User> _repository)
        {
            this._repository = _repository;
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

        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAll();
        }

        public User GetUserById(int id)
        {
            return _repository.GetById(id);
        }

        public bool AddNewUser(User user)
        {
            try
            {
                _repository.Insert(user);
                _repository.Save();
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }

        public bool EditUser(User user)
        {
            try
            {
                _repository.Update(user);
                _repository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(int UserId)
        {
            try
            {
                User user = _repository.GetById(UserId);
                _repository.Delete(user);
                _repository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //ctr + k + s



        #endregion
    }
}