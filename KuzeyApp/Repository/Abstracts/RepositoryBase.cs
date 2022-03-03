using KuzeyApp.Data;
using KuzeyApp.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyApp.Repository.Abstracts
{
    //sadece sql ve entity için kullanılıyor.

   
    public abstract class RepositoryBase<T, TId> : IRepository<T, TId>, IDisposable where T : BaseEntity, new()
    {
        protected KuzeyContext _context;
        public DbSet<T> Table { get; protected set; }
        protected RepositoryBase()
        {
            _context = new KuzeyContext();
            Table = _context.Set<T>();
        }
        public virtual void Add(T entity, bool isSaveLater = false)
        { 
            Table.Add(entity);
            if (!isSaveLater)
            {
                this.Save();
            }
        }

        public virtual IQueryable<T> Get(Func<T, bool> predicate = null)
        {
            return predicate == null ? Table : Table.Where(predicate).AsQueryable();


        }
        public virtual IQueryable<T> Get(string[] includes,Func<T, bool> predicate = null)
        {
            IQueryable<T> query=Table;
            foreach (var include in includes)
            {
               query= Table.Include(include);
            }
            return predicate == null ? query:query.Where(predicate).AsQueryable();


        }

        public virtual T GetById(TId id)
        {
           return Table.Find(id);
        }

        public virtual void Remove(T entity, bool isSaveLater = false)
        {
            throw new NotImplementedException();
        }

        public virtual int Save()
        {
           return _context.SaveChanges();
        }

        public virtual void Update(T entity, bool isSaveLater = false)
        {
            Table.Update(entity);
            if (!isSaveLater)
            {
                this.Save();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
