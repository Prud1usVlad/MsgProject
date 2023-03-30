using Msg.Core.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> GetOrderAsync(long id);
        public Task<List<Order>> GetOrdersAsync();
        public Task<long> AddOrderAsync(Order order);
        public Task DeleteOrderAsync(long id);
        public Task ConfirmOrder(long order);
    }
}
