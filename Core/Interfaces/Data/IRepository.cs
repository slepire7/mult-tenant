using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Interfaces.Data
{
    public interface IRepository<TModel, TContext> where TModel : Model.BaseEntity where TContext : DbContext
    {
        TModel Get(Guid id);
        TModel Get(Func<TModel, bool> filter);
        TModel GetAndJoinEntity<TModelJoin>(Func<TModel, bool> filter, Expression<Func<TModel, TModelJoin>> includes);
        List<TModel> GetAll();
        Task Add(TModel model);
        Task SaveChanges();
    }
}
