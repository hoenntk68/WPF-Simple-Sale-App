using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> List();
        void Add(OrderDetail orderDetail);
        void Update(OrderDetail orderDetail);
        void Remove(OrderDetail orderDetail);
    }
}
