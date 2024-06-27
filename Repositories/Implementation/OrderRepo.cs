using BusinessObjects;
using DataAccessObjects;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class OrderRepo : IOrderRepo
    {
        private readonly IGenericDAO<Order> _dao;
        public OrderRepo(IGenericDAO<Order> dao)
        {
            _dao = dao;
        }

        public void Add(Order order)
            => _dao.Add(order);

        public void ChangeStatus(Order order, OrderStatus orderStatus)
        {
            order.OrderStatus = orderStatus;
            _dao.Update(order);
        }

        public void Delete(Order order)
            => _dao.Delete(order);

        public (List<Order> orderList, int pageCount) GetAll(int page, int pageSize)
        {
            int currentPage = page < 1 ? 1 : page;
            int currentPageSize = pageSize < 1 ? 1 : pageSize;
            List<Order> orders = _dao
                .Query()
                .Skip((currentPage - 1) * currentPageSize)
                .Include(x=>x.User)
                .OrderByDescending(x => x.OrderDate)
                .Take(currentPageSize)
                .ToList();
            int count = _dao
                .Query()
                .Count();
            int pageCount = (int)Math.Ceiling((double)count / currentPageSize);
            return (orders, pageCount);
        }

        public (List<Order> orderList, int pageCount) GetByStatus(OrderStatus orderStatus, int page, int pageSize)
        {
            int currentPage = page < 1 ? 1 : page;
            int currentPageSize = pageSize < 1 ? 1 : pageSize;
            List<Order> orders = _dao
                .Query()
                .Where(x=> x.OrderStatus == orderStatus)
                .Include(x => x.User)
                .OrderByDescending(x => x.OrderDate)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();
            int count = _dao
                .Query()
                .Where(x => x.OrderStatus == orderStatus)
                .Count();
            int pageCount = (int)Math.Ceiling((double)count / currentPageSize);
            return (orders, pageCount);
        }

        public (List<Order> orderList, int pageCount) GetCustomerOrderByStatus(int customerId, OrderStatus orderStatus, int page, int pageSize)
        {
            int currentPage = page < 1 ? 1 : page;
            int currentPageSize = pageSize < 1 ? 1 : pageSize;
            List<Order> orders = _dao
                .Query()
                .Where(x => x.OrderStatus == orderStatus && x.UserId.Equals(customerId))
                .Include(x => x.User)
                .OrderByDescending(x => x.OrderDate)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();
            int count = _dao
                .Query()
                .Where(x => x.OrderStatus == orderStatus && x.UserId.Equals(customerId))
                .Count();
            int pageCount = (int)Math.Ceiling((double)count / currentPageSize);
            return (orders, pageCount);
        }

        public (List<Order> orderList, int pageCount) GetCustomerOrders(int customerId, int page, int pageSize)
        {
            int currentPage = page < 1 ? 1 : page;
            int currentPageSize = pageSize < 1 ? 1 : pageSize;
            List<Order> orders = _dao
                .Query()
                .Where(x=>x.UserId.Equals(customerId))
                .Include(x => x.User)
                .OrderByDescending(x => x.OrderDate)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();
            int count = _dao
                .Query()
                .Where(x=>x.UserId.Equals(customerId))
                .Count();
            int pageCount = (int)Math.Ceiling((double)count / currentPageSize);
            return (orders, pageCount);
        }

        public Order? GetOrder(int id)
        {
            return _dao
                .Query()
                .Where(x => x.OrderId.Equals(id))
                .Include(x=>x.OrderDetails)
                .SingleOrDefault();
        }

        public void Update(Order order)
            => _dao.Update(order);
    }
}
