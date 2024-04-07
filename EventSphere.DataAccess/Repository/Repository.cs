using EventSphere.DataAccess.Data;
using EventSphere.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _db;
        internal DbSet<T> dbSet;
        private static readonly char[] commaSeparator = { ',' };

        public Repository(ApplicationDBContext db)
        {
            _db = db;
            dbSet = db.Set<T>();  //dbSet with the corresponding DbSet<T> from the context
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>>? filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;

            if (tracked) // to aboid tracking by EF Core
            {
                query = dbSet; // here we assign the complete DBset to the query        
            }
            else
            {
                query = dbSet.AsNoTracking();  //this AsNoTracking stop auto Tracking in EF core
                // here we assign the complete DBset to the query
            }

            query = query.Where(filter);

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var i in includeProperties.Split(commaSeparator, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(i);
                }
            }

            return query.FirstOrDefault();


        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {

            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var i in includeProperties.Split(commaSeparator, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(i);
                }

            }
            return query.ToList();

        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }


        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

    }
}
