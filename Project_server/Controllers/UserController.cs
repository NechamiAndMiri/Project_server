using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities;

/// <summary>
/// using the tables:
///     1. users
/// </summary>

namespace Project_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IUserBL userBL;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        // GET api/<UserController>/5

        /// screens:
        /// 1. login
        [HttpGet("{userName}, {password}")]
        public TblUser Get(string userName, string password)
        {
            //return current user
            return userBL.getUser(userName, password);
        }

    
    }
}
