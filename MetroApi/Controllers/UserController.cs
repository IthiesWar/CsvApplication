using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using OnlineMedicalStore.Data; 

namespace METROAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
         private readonly ApplicationDBContext _dbContext;
        public UserController(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }
        /*
        private static List<User> _UserDetails=new List<User>()
        {
            new User {UserID=1,UserName="harshad",UserEmail="harshad@gmail.com",UserBalance=9,UserPhone="6655443321",UserPassword="har@@66"},
            new User {UserID=2,UserName="kumaresh",UserEmail="kumar@gmail.com",UserBalance=10,UserPhone="9988776655",UserPassword="kumar@@66"}
            
        };*/

        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(_dbContext.users);
        }

        [HttpGet("{id}")]
        public  IActionResult GetUserDetails(int id)
        {
            var UserDetails=_dbContext.users.FirstOrDefault(U=>U.UserID==id);
            if(UserDetails==null)
            {
                return NotFound();
            }
            return Ok(UserDetails);
        }

       
        [HttpPost]
        public IActionResult PostUserDetails([FromBody]User UserDetails)
        {
            _dbContext.users.Add(UserDetails);
             _dbContext.SaveChanges();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id,[FromBody] User UserDetails)
        {
            var index=_dbContext.users.FirstOrDefault(U=>U.UserID==id);
            if(index==null)
            {
                return NotFound();
            }
            index.UserName=UserDetails.UserName;
            index.UserEmail=UserDetails.UserEmail;
            index.UserBalance=UserDetails.UserBalance;
            index.UserPhone=UserDetails.UserPhone;
            index.UserPassword=UserDetails.UserPassword;
            _dbContext.SaveChanges();
            return Ok();
        }
          
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var DeleteUser=_dbContext.users.FirstOrDefault(U=>U.UserID==id);
            if(DeleteUser==null)
            {
                return NotFound();
            }
            _dbContext.users.Remove(DeleteUser);
             _dbContext.SaveChanges();
            return Ok();
        }

    }

    
}