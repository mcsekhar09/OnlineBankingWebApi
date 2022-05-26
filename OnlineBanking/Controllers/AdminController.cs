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
    public class AdminController : ControllerBase
    {
        public Banking_ManagmentContext db;
        public AdminController(Banking_ManagmentContext _db)
        {
            db = _db;
        }

        public IActionResult GetAll()
        {
            return Ok(db.Admin);
        }

        [HttpPost]
            public IActionResult Login(Admin admin)
            {
                var adminlogin = db.Admin.Where(t => t.Adminid == admin.Adminid && t.Passwords == admin.Passwords).FirstOrDefault();
                if (adminlogin != null)
                {
                    return Ok();
                }
                else
                    return Unauthorized();

            }

       

        }
    }

