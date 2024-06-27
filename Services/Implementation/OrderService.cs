using BusinessObjects;
using Repositories;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _repository;

        public OrderService(IOrderRepo repository)
        {
            _repository = repository;
        }

        public void Add(Order order)
            => _repository.Add(order);

        public void ChangeStatus(Order order, OrderStatus orderStatus)
            => _repository.ChangeStatus(order, orderStatus);

        public void Delete(Order order)
            => _repository.Delete(order);

        public (List<Order> orderList, int pageCount) GetAll(int page, int pageSize) 
            => _repository.GetAll(page, pageSize);

        public (List<Order> orderList, int pageCount) GetByStatus(OrderStatus orderStatus, int page, int pageSize)
            => _repository.GetByStatus(orderStatus, page, pageSize);

        public (List<Order> orderList, int pageCount) GetCustomerOrderByStatus(int customerId, OrderStatus orderStatus, int page, int pageSize)
            => _repository.GetCustomerOrderByStatus(customerId, orderStatus, page, pageSize);

        public (List<Order> orderList, int pageCount) GetCustomerOrders(int customerId, int page, int pageSize)
            => _repository.GetCustomerOrders(customerId,page, pageSize);

        public Order? GetOrder(int orderId)
            => _repository.GetOrder(orderId);

        public void Update(Order order)
            => _repository.Update(order);
    }
}
