using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public Banking_ManagmentContext db;
        public UserController(Banking_ManagmentContext _db)
        {
            db = _db;
        }

        public IActionResult Get()
        {
            return Ok(db.Account);
        }

        [HttpPost("user")]
        public IActionResult Login(Account user)
        {
            var login = db.Account.Where(t => t.CustomerId == user.CustomerId && t.Password == user.TransactionPassword).FirstOrDefault();
            if (login != null)
            {
                return Ok();
            }
            else
                return Unauthorized();

        }
        [HttpGet]
        public IActionResult Bankstatement(int AccountNum, DateTime fromdate,DateTime todate)
        {
            
           var result = db.Transactions.Where(x => x.FromAcc == AccountNum && x.TransactionDate >= fromdate &&  x.TransactionDate <= todate);
            
            return Ok(result);
        }


    }
}
