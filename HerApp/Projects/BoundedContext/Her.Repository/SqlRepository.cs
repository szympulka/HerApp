using System.Linq;
using System.Threading.Tasks;
using Her.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Her.Repository
{
    public class SqlRepository<T> : HerContext, ISqlRepository<T> where T : class
    {
        public virtual IQueryable<T> All()
        {
            return base.Set<T>().AsQueryable();
        }

        public T Find(params object[] keys)
        {
            return base.Find<T>(keys);
        }

        public EntityEntry Add(T entry)
        {
            return base.Add(entry);
        }

        public System.Threading.Tasks.Task AddAsync(T entry)
        {
            return base.AddAsync(entry);
        }

        public void AddRange(T entry)
        {
            base.AddRange(entry);
        }

        public System.Threading.Tasks.Task AddRangeAsync(T entry)
        {
            return base.AddRangeAsync(entry);
        }

        public EntityEntry Remove(T entry)
        {
            return base.Remove(entry);
        }

        public void RemoveRange(T entry)
        {
             base.RemoveRange(entry);
        }

        public EntityEntry Update(T entry)
        {
            return base.Update(entry);
        }

        public EntityEntry Attach(T entry)
        {
            return base.Attach(entry);
        }

        public void SaveChangesAsync()
        {
            base.SaveChangesAsync();
        }

#pragma warning disable 108,114
        public void SaveChanges()
#pragma warning restore 108,114
        {
            base.SaveChanges();
        }

    }
}
