using BusinessObject.Models;
using DataAccess.Model;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instancelock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            List<Order> orderList;
            try
            {
                using (var ctx = new WPF_Sale_ManagerContext())
                {
                    orderList = ctx.Orders.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderList;
        }

        public IEnumerable<Order> GetOrderByDate(DateTime startDate, DateTime endDate)
        {
            List<Order> orderList;
            try
            {
                using (var ctx = new WPF_Sale_ManagerContext())
                {
                    orderList = ctx.Orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderList;
        }

        public IEnumerable<Order> GetOrderByEmail(string email)
        {
            List<Order> orderList;
            try
            {
                using (var ctx = new WPF_Sale_ManagerContext())
                {
                    int memberId = ctx.Members.Where(m => m.Email == email).FirstOrDefault().MemberId;
                    orderList = ctx.Orders.Where(o => o.MemberId == memberId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderList;
        }

        public Order GetOrderById(int id)
        {
            Order order = null;
            try
            {
                using (var ctx = new WPF_Sale_ManagerContext())
                {
                    order = ctx.Orders.SingleOrDefault(m => m.OrderId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public void AddOrder(Order order)
        {
            try
            {
                Order m = GetOrderById(order.OrderId);
                if (m == null)
                {
                    using (var ctx = new WPF_Sale_ManagerContext())
                    {
                        ctx.Orders.Add(order);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                Order m = GetOrderById(order.OrderId);
                if (m != null)
                {
                    using (var ctx = new WPF_Sale_ManagerContext())
                    {
                        ctx.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Order does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteOrder(Order order)
        {
            try
            {
                Order m = GetOrderById(order.OrderId);
                if (m != null)
                {
                    using (var ctx = new WPF_Sale_ManagerContext())
                    {
                        ctx.Orders.Remove(order);
                        ctx.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Order does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Order> FindAllBy(OrderFilter filter)
        {
            if (filter != null)
            {
                IEnumerable<Order> orderList = OrderDAO.Instance.FindAll(order => (filter.StartDate == null || order.OrderDate >= filter.StartDate) &&
                                                              (filter.EndDate == null || order.OrderDate <= filter.EndDate) ||
                                                              (filter.StartDate != null && filter.EndDate != null && order.OrderDate >= filter.StartDate && order.OrderDate <= filter.EndDate)).OrderByDescending(order => order.OrderDate).ToList();
                return orderList;
            }
            return GetAllOrders();
        }

        public IEnumerable<Order> FindAll(Expression<Func<Order, bool>> predicate)
        {
            List<Order> orders = new List<Order>();
            using (var saleManagerContext = new WPF_Sale_ManagerContext())
            {
                orders = saleManagerContext.Orders.Where(predicate).ToList();
            }
            return orders;
        }
    }
}
