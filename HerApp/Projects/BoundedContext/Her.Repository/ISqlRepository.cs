using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Her.Repository
{
    public interface ISqlRepository<T>
    {
        IQueryable<T> All();
        T Find(params object[] keys);
        EntityEntry Add(T entry);
		System.Threading.Tasks.Task AddAsync(T entry) ;
        void AddRange(T entry) ;
        System.Threading.Tasks.Task AddRangeAsync(T entry) ;
        EntityEntry Remove(T entry) ;
        void RemoveRange(T entry) ;
        EntityEntry Update(T entry) ;
        EntityEntry Attach(T entry) ;
        void SaveChangesAsync();
        void SaveChanges();
    }
}
