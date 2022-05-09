using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        SqlOperations sqlOperations = new SqlOperations();
        string msg = string.Empty;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public string Get(string login, string password)
        {
            if (sqlOperations.CheckAuthorization(login, password))
            {
                return "Success!";
            }
            return "Login failed!";
        }
    }
}