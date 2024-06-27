using BusinessObjects;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepo _repo;
        public OrderDetailService(IOrderDetailRepo repo)
        {
            _repo = repo;
        }

        public void Add(OrderDetail orderDetail)
            => _repo.Add(orderDetail);

        public List<OrderDetail> GetByOrderId(int orderId)
            => _repo.GetOrderDetailsByOrderId(orderId);

        public OrderDetail? GetOrderDetail(int orderDetailId)
            => _repo.GetOrderDetail(orderDetailId);
    }
}
