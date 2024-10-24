using Doctor.Data.APP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Doctor.Business
{
    public class Repository<T> : IRepository<T> where T : class
        {
            protected readonly DoctorContext _context;

            public Repository(DoctorContext context)
            {
                _context = context;
            }

            public T GetById(int id)
            {
                return _context.Set<T>().Find(id);
            }

            public IEnumerable<T> GetAll()
            {
                return _context.Set<T>().ToList();
            }

            public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
            {
                return _context.Set<T>().Where(predicate).ToList();
            }

            public void Add(T entity)
            {
                _context.Set<T>().Add(entity);
            }

            public void AddRange(IEnumerable<T> entities)
            {
                _context.Set<T>().AddRange(entities);
            }

            public void Remove(T entity)
            {
                _context.Set<T>().Remove(entity);
            }

            public void RemoveRange(IEnumerable<T> entities)
            {
                _context.Set<T>().RemoveRange(entities);
            }

      
public IEnumerable<T> Finds(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

    }
}


