using METROAPI;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using METROAPI.Controllers;
namespace METROAPI.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController:ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public OrderController(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }

        // private static List<Order> _OrderDetails=new List<Order>()
        // {
        //    new Order{OrderID=1,FromLocation="annanagar",ToLocation="chepauk",TicketPrice=100,Date="2000-09-09"},
        //      new Order{OrderID=1,FromLocation="annanagar",ToLocation="chepauk",TicketPrice=100,Date="2000-09-09"}
        // };
         [HttpGet]
        public IActionResult GetTicket()
        {
            return Ok(_dbContext.orders);
        }
        [HttpGet("{id}")]
        public IActionResult PutTicket(int id)
        {
             var OrderDetails=_dbContext.orders.FirstOrDefault(O=>O.OrderID==id);
            if(OrderDetails==null)
            {
                return NotFound();
            }
            return Ok(OrderDetails);
        }
        [HttpPost]
        public IActionResult PostTicket([FromBody]Order OrderDetails)
        {
            _dbContext.orders.Add(OrderDetails);
            _dbContext.SaveChanges();
            return Ok();
        }
         [HttpPut("{id}")]
        public IActionResult PutMedicine(int id,[FromBody] Order OrderDetails)
        {
            var index=_dbContext.orders.FirstOrDefault(O=>O.OrderID==id);
            if(index==null)
            {
                return NotFound();
            }
           index.FromLocation=OrderDetails.FromLocation;
            index.ToLocation=OrderDetails.ToLocation;
            index.TicketPrice=OrderDetails.TicketPrice;
            index.Date=OrderDetails.Date;
            _dbContext.SaveChanges();
            return Ok();
           
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var DeleteOrder=_dbContext.orders.FirstOrDefault(O=>O.OrderID==id);
            if(DeleteOrder==null)
            {
                return NotFound();
            }
                _dbContext.orders.Remove(DeleteOrder);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}