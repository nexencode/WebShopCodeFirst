using Repository.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepository
{
    public class GenericRepositort<T> : IGenericRepository<T> where T : class
    {
        private WebShopDbContext _context;
        private DbSet<T> table;

        public GenericRepositort()
        {
            this._context = new WebShopDbContext();
            table = _context.Set<T>();
        }

        public GenericRepositort(WebShopDbContext dbContext)
        {
            this._context = dbContext;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        //Pitanje!!!
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(T obj)
        {
            table.Remove(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
