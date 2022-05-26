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
    public class BenifiaciaryController : ControllerBase
    {
        public Banking_ManagmentContext db;
        public BenifiaciaryController(Banking_ManagmentContext _db)
        {
            db = _db;
        }

        public IActionResult GetAll()
        {
            return Ok(db.Beneficiary);
        }
        [HttpPost]
        public IActionResult AddBenificiary(Beneficiary beneficiary)
        {
            Random r = new Random();
            var request = db.Beneficiary.Where(x => x.BeneficiaryAccNo == beneficiary.BeneficiaryAccNo).FirstOrDefault();
            if (request == null)
            {
                beneficiary.BeneficiaryId = r.Next(1000, 2000);
                db.Beneficiary.Add(beneficiary);
                db.SaveChanges();
                return Ok(beneficiary);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
