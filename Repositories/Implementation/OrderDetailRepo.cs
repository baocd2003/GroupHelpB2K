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
    public class OrderDetailRepo : IOrderDetailRepo
    {
        private readonly IGenericDAO<OrderDetail> _dao;
        public OrderDetailRepo(IGenericDAO<OrderDetail> dao)
        {
            _dao = dao;
        }

        public void Add(OrderDetail orderDetail)
            => _dao.Add(orderDetail);

        public OrderDetail? GetOrderDetail(int orderDetailId)
            => _dao.GetById(orderDetailId);

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
            => _dao.Query().Where(x=>x.OrderId.Equals(orderId)).Include(x=>x.Book).ToList();
    }
}
