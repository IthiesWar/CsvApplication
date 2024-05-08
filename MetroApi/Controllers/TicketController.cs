using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using OnlineMedicalStore.Data; 

namespace METROAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController:ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public TicketController(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }
        /*
        private static List<Ticket> _TicketDetails=new List<Ticket>()
        {
            new Ticket{TicketID=1,FromLocation="annanagar",ToLocation="chepauk",TicketPrice=50},
             new Ticket{TicketID=1,FromLocation="annanagar",ToLocation="chepauk",TicketPrice=50}
        };*/
        [HttpGet]
        public IActionResult GetTicket()
        {
            return Ok(_dbContext.tickets);
        }
        [HttpGet("{id}")]
        public IActionResult PutTicket(int id)
        {
             var TicketDetails=_dbContext.tickets.FirstOrDefault(T=>T.TicketID==id);
            if(TicketDetails==null)
            {
                return NotFound();
            }
            return Ok(TicketDetails);
        }
        [HttpPost]
        public IActionResult PostTicket([FromBody]Ticket TicketDetails)
        {
            _dbContext.tickets.Add(TicketDetails);
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult PutMedicine(int id,[FromBody] Ticket TicketDetails)
        {
            var index=_dbContext.tickets.FirstOrDefault(T=>T.TicketID==id);
            if(index==null)
            {
                return NotFound();
            }
            index.FromLocation=TicketDetails.FromLocation;
            index.ToLocation=TicketDetails.ToLocation;
            index.TicketPrice=TicketDetails.TicketPrice;
            _dbContext.SaveChanges();
            return Ok();
        }
          [HttpDelete("{id}")]
          public IActionResult DeleteTicket(int id)
          {
            var DeleteTicket=_dbContext.tickets.FirstOrDefault(T=>T.TicketID==id);
            if(DeleteTicket==null)
            {
                return NotFound();
            }
            _dbContext.tickets.Remove(DeleteTicket);
            _dbContext.SaveChanges();
            return Ok();
          }
    }
}