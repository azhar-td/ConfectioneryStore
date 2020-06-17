using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfectioneryStore.Services
{
    public interface IDataServicePro<TEntity>
    {
        IEnumerable<TEntity> GetAllOrdersWithDetail();
        TEntity GetOrderWithDetailByCustomer(string cusName);
    }
}
