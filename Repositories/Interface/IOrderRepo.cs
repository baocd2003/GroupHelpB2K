using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IOrderRepo
    {
        public void Add(Order order);
        public void Update(Order order);
        public void Delete(Order order);
        public void ChangeStatus(Order order, OrderStatus orderStatus);
        public (List<Order> orderList, int pageCount) GetAll(int page, int pageSize);
        public (List<Order> orderList, int pageCount) GetByStatus(OrderStatus orderStatus, int page, int pageSize);
        public (List<Order> orderList, int pageCount) GetCustomerOrders(int customerId, int page, int pageSize);
        public (List<Order> orderList, int pageCount) GetCustomerOrderByStatus(int customer, OrderStatus orderStatus, int page, int pageSize);
        public Order? GetOrder(int id);

    }
}
