using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class Repository<TModel, TContext> : Core.Interfaces.Data.IRepository<TModel, TContext> where TModel : Core.Model.BaseEntity where TContext : DbContext
    {
        private readonly TContext _context;
        public Repository(TContext _context)
        {
            this._context = _context;
        }

        public async Task Add(TModel model)
        {
            await _context.AddAsync(model);
        }

        public TModel Get(Guid id)
        {
            return _context.Set<TModel>().Find(id);
        }
        public TModel Get(Func<TModel, bool> filter)
        {
            return _context.Set<TModel>().Where(filter).FirstOrDefault();
        }
        public TModel GetAndJoinEntity<TModelJoin>(Func<TModel, bool> filter, Expression<Func<TModel, TModelJoin>> includes)
        {
            return _context.Set<TModel>()?.Include(includes).Where(filter).FirstOrDefault();
        }
        public List<TModel> GetAll()
        {
            return _context.Set<TModel>().ToList();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
