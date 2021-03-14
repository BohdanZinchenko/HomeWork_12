using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;

namespace DepsWebApp.Controllers
{
    /// <summary>
    /// Auth controller for registrations user 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        /// <summary>
        /// Constructor for Auth Controller
        /// </summary>
        /// <param name="userService"></param>
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Register method
        /// Allow anonymous for create user
        /// </summary>
        /// <param name="user"></param>
        /// <returns> Basic64 </returns>
        [HttpPost]
        public IActionResult Register(User user)
        {

            _userService.AddUser(user);

            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(user.Login + ":" + user.Password));

            return Ok($"Basic {svcCredentials}");
        }
    }

    
    
}
