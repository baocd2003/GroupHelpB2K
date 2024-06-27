using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Shipped,
        Delivered,
        Cancelled,
        DeliveryFailed
    }

    public enum AccountStatus
    {
        InActive,
        Active
    }
    public enum BookStatus
    {

    }
    public enum UserRole
    {
        Customer,
        Staff
    }

    public enum LoginUserRole
    {
        Customer,
        Staff,
        Admin
    }
    public enum CommentStatus
    {
        Show,
        Hide
    }
}
