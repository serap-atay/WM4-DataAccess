using KuzeyApp.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyApp.Repository.Abstracts
{
    //in =>parametre verdiğim değeri kullan ama içindekini değiştime 
    //out=> parametre kullanılan değerin geri dönüş değeri olması lazım.
    //SqlRepositoryBase --MongoRepositoryBase karıştırmamak için kullanabiliriz.
    public interface IRepository< T,in TId>where T:BaseEntity
    {
        T GetById(TId id);
        IQueryable<T> Get(Func<T, bool> predicate = null);

        void Add(T entity, bool isSaveLater = false);
        void Remove (T entity, bool isSaveLater = false);
        void Update(T entity, bool isSaveLater = false);
        int Save();
    }
}
