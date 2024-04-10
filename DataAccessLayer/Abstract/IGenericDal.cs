using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task InsertAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
