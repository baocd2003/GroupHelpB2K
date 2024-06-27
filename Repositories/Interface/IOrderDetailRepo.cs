using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IOrderDetailRepo
    {
        void Add(OrderDetail orderDetail);
        OrderDetail? GetOrderDetail(int orderDetailId);
        List<OrderDetail> GetOrderDetailsByOrderId(int orderId);
    }
}
