using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ConfectioneryStore.DTO;
using ConfectioneryStore.Models;
using ConfectioneryStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConfectioneryStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IDataService<Order> _orderService;
        private readonly IDataServicePro<OrderDetail> _orderServicePro;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IDataService<Order> orderService,IDataServicePro<OrderDetail> orderServicePro, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _orderServicePro = orderServicePro;
            _logger = logger;
        }

        // GET: api/Order
        [AllowAnonymous]
        [HttpGet]
        //[Route("api/order/getOrders")]
        public IActionResult Get()
        {
            var result = new List<OrderDetail>();
            try
            {
                result = _orderServicePro.GetAllOrdersWithDetail().ToList();
                if (!result.Any())
                {
                    return NotFound("No order found in DB");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());
            }
            return Json(result);
        }

        // GET: api/Order/Azhar
        [HttpGet("{customer}", Name = "Get")]
        public IActionResult Get(string customer)
        {
            var result = new OrderDetail();
            try
            {
                result=_orderServicePro.GetOrderWithDetailByCustomer(customer);
                if (result==null)
                {
                    return NotFound("No order found with the customer name.."+customer);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());
            }
            return Json(result);
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            try
            {
                if (order == null)
                {
                    return StatusCode(400);//Validation failed
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());
            }
            _orderService.Add(order);
            return Json(order);
        }
    }
}
