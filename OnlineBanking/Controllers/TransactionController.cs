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
    public class TransactionController : ControllerBase
    {
        public Banking_ManagmentContext db;


        public TransactionController(Banking_ManagmentContext _db)
        {
            db = _db;
        }
        public IActionResult GetAll()
        {
            return Ok(db.Transactions);
        }

        [HttpPost]
        public IActionResult initiatepayment(Transactions transactions)
        {
            Random r = new Random();

            transactions.TransactionId = r.Next(2000, 3000);
            db.Transactions.Add(transactions);
            db.SaveChanges();
            return Ok(transactions);

        }

        

    }
}

