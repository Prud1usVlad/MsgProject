using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Msg.BLL.BasicServices;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.Core.RequestModels;
using Msg.Core.ResponseModels;

namespace MsgWeb.Controllers.Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ErrorHandlingControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMailingService _mailingService;

        public OrdersController(IOrderService orderService, IMailingService mailingService)
        {
            _orderService = orderService;
            _mailingService = mailingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetOrders()
        {
            try
            {
                var orders = await _orderService.GetOrdersAsync();
                return Ok(orders.Select(GetViewModelFromOrder));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<IEnumerable<OrderViewModel>>(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderViewModel>> GetOrderById(long id)
        {
            try
            {
                var deviceType = await _orderService.GetOrderAsync(id);

                return Ok(GetViewModelFromOrder(deviceType));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<OrderViewModel>(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<long>> PostOrder(OrderModel model)
        {
            try
            {
                var order = GetOrderFromModel(model);

                order.Date = DateOnly.FromDateTime(DateTime.Now);
                order.Processed = false;

                return await _orderService.AddOrderAsync(order);
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        [HttpPost("Confirm/{id}")]
        public async Task<IActionResult> ConfirmOrder(long id)
        {
            try
            {
                await _orderService.ConfirmOrder(id);
                return Ok("Order confirmed!");
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            try
            {
                await _orderService.DeleteOrderAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        private OrderViewModel GetViewModelFromOrder(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                PackTypeId = order.PackTypeId,
                Email = order.Email,
                Phone = order.Phone,
                Processed = order.Processed,
                Date = order.Date,
                PackType = new PackTypeModel
                {
                    Id = order.PackTypeId,
                    Name = order.PackType.Name,
                    Price = order.PackType.Price,
                    Image = order.PackType.Image,
                }

            };
        }

        private Order GetOrderFromModel(OrderModel model)
        {
            return new Order
            {
                Id = model.Id,
                PackTypeId = model.PackTypeId,
                Email = model.Email,
                Phone = model.Phone,
            };
        }

    }
}
