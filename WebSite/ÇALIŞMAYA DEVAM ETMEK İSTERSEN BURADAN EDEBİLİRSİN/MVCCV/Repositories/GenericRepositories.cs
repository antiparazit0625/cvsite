using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MVCCV.Models.Entity;
namespace MVCCV.Repositories
{
    public class GenericRepositories<T> where T : class, new()
    {
        DbCVEntities vt = new DbCVEntities();
        public List<T> List()
        {
            return vt.Set<T>().ToList();
        }
        public void TAdd(T p)
        {
            vt.Set<T>().Add(p);
            vt.SaveChanges();

        }
        public void TDelete(T p)
        {
            vt.Set<T>().Remove(p);
            vt.SaveChanges();
        }
        public T TGet(int ıd)
        {
            return vt.Set<T>().Find(ıd);
        }
        public void TUpdate (T p)
        {
            vt.SaveChanges();
        }
        public T Find(Expression<Func<T,bool>> where)
        {
            return vt.Set<T>().FirstOrDefault(where);
        }
    }
}
    
