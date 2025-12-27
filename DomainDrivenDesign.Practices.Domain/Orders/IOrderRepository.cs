using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainDrivenDesign.Practices.Domain.Orders.Order;

namespace DomainDrivenDesign.Practices.Domain.Orders
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos);
        Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
