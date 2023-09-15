using Visitor.DataAccess;
using Visitor.DataAccess.Factory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Visitor.Service.Interfaces;
using Visitor.Service.Attributes;

namespace Visitor.Service
{
    public class BaseEntityService<T> : IDisposable where T : class
    {
        protected VisitorDBContext _visitorDbContext;

        public BaseEntityService()
        {
            _visitorDbContext = VisitorDataContextFactory.VisitorDBContext();
        }

        public BaseEntityService(VisitorDBContext context)
        {
            _visitorDbContext = context;
        }

        protected void Add(T entity)
        {
            _visitorDbContext.Set<T>().Add(entity);
            SaveChanges();
        }

        protected virtual void Update(T entity)
        {
            _visitorDbContext.Set<T>().Attach(entity);
            _visitorDbContext.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        protected virtual void Update(object entity, IUpdateEntity updateEntity)
        {
            PropertyInfo[] properties = updateEntity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.IsDefined(typeof(ExcludeAttribute), false) == false).ToArray();
            foreach (PropertyInfo property in properties)
            {
                var propertyValue = property.GetValue(updateEntity);
                bool isIncluded = property.IsDefined(typeof(IncludeAttribute), false);
                if (propertyValue != null || isIncluded)
                    _visitorDbContext.Entry(entity).Property(property.Name).CurrentValue = propertyValue;
            }
        }

        public virtual void CreateOrUpdate(IBaseDTO entityDTO)
        {
        }

        public virtual void CreateOrUpdate(IBaseDTO entityDTO, out string[] result)
        {
            result = default(string[]);
        }

        public virtual void CreateOrUpdate2<U>(U entityDTO, out string[] result)
        {
            result = default(string[]);
        }

        protected void Delete(T entity)
        {
            _visitorDbContext.Set<T>().Remove(entity);
            SaveChanges();
        }

        protected void SaveChanges()
        {
            _visitorDbContext.SaveChanges();
        }

        public virtual IQueryable<T> All()
        {
            return _visitorDbContext.Set<T>();
        }

        public void Dispose()
        {
            _visitorDbContext.Dispose();
        }
    }
}
