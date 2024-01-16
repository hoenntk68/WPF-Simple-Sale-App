using BusinessObject.Models;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetOrdersByDate(DateTime startDate, DateTime endDate);
        IEnumerable<Order> GetOrdersByUser(string email);
        Order GetOrderById(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        IEnumerable<Order> FindAllBy(OrderFilter filter);
        IEnumerable<Order> FindByEmail(string email);
    }
}
