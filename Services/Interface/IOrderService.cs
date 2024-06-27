using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IOrderService
    {
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
        void ChangeStatus(Order order, OrderStatus orderStatus);
        (List<Order> orderList, int pageCount) GetAll(int page, int pageSize);
        (List<Order> orderList, int pageCount) GetByStatus(OrderStatus orderStatus, int page, int pageSize);
        (List<Order> orderList, int pageCount) GetCustomerOrders(int customerId, int page, int pageSize);
        (List<Order> orderList, int pageCount) GetCustomerOrderByStatus(int customerId, OrderStatus orderStatus, int page, int pageSize);
        Order? GetOrder(int orderId);
    }
}
