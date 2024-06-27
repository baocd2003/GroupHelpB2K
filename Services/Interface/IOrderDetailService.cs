using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IOrderDetailService
    {
        void Add(OrderDetail orderDetail);
        List<OrderDetail> GetByOrderId(int orderId);
        OrderDetail? GetOrderDetail(int orderDetailId);
    }
}
