using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.API.Core.Abstractions.Repositories.Common
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);
        public Task Insert (T model);
        public Task Delete (T model);
    }
}
