using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models.Products
{
    public class Category
    {

        #region Fields and Properties
        private IGenericRepository<Category> _repository;

        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
        public bool IsActive { get; set; }
        #endregion

        #region Constructors
        public Category()
        {
            this._repository = new GenericRepositort<Category>();

        }
        public Category(IGenericRepository<Category> _repository)
        {
            this._repository = _repository;
        }
        public Category(string categoryDescription, bool isActive)
        {
            CategoryDescription = categoryDescription;
            IsActive = isActive;
        }
        #endregion

        #region Methods

        public IEnumerable<Category> GetAllCategories()
        {
            return _repository.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _repository.GetById(id);
        }

        public bool AddNewCategories(Category category)
        {
            try
            {
                _repository.Insert(category);
                _repository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditCategory(Category category)
        {
            try
            {
                _repository.Update(category);
                _repository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCategory(int CategoryId)
        {
            try
            {
                Category category = _repository.GetById(CategoryId);
                _repository.Delete(category);
                _repository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        #endregion

    }
}