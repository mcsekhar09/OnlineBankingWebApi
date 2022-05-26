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
    public class AccountopenController : ControllerBase
    {
        public Banking_ManagmentContext db;
        public AccountopenController(Banking_ManagmentContext _db)
        {
            db = _db;
        }

        public IActionResult GetAll()
        {
            return Ok(db.AccountRequest);
        }

        [HttpGet]
        public IActionResult Viewrequest()
        {
            var application = db.AccountRequest.Where(x => x.Status == "Pending").Select(y => new { y.RequestId, y.FirstName, y.Lastname, y.EmailId, y.MobileNum, y.AddharCard, y.PermenentAddress });
            return Ok(application);

        }

        [HttpGet("{RequestId}")]
        public IActionResult Viewrequest(int Requestid)
        {
            var application = db.AccountRequest.FirstOrDefault(x => x.RequestId == Requestid);
            return Ok(application);
        }

        [HttpPost]
        public IActionResult CreateAccount(AccountRequest Account_Request)
        {
            Random r = new Random();
            var request = db.AccountRequest.Where(x => x.EmailId == Account_Request.EmailId).FirstOrDefault();
            if (request == null)
            {
                Account_Request.RequestId = r.Next(1000, 2000);
                db.AccountRequest.Add(Account_Request);
                db.SaveChanges();
                return Ok(Account_Request);
            }
            else
            {
                return BadRequest();
            }

           

        }

        [HttpPut("{requestId}")]

        public IActionResult AdminApproval(int requestId, AccountRequest application)
        {
            
            application.Status = "Approved";
            db.AccountRequest.Update(application);
            db.SaveChanges();
            return Ok();
        }


    }
}
