using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
// using fbi.Models;
// using fbi.Service;
using Login.LoginService;
using lesson2.Login.Interface;
using lesson2.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyModelsLib;
using MyModelsLib.Interface;
// using Login;
// using Login.LoginService;


namespace lesson2.Controllers

{
    [Route("[controller]")]
    public class LoginController : BaseCcntroller
    {
        // public bool ifExist(string name, string password)
        // {

        // }
        // private readonly ILogger<LoginController> _logger;
        private ILogin _login;
        private IWorkerService _worker;
        public LoginController(ILogin i, IWorkerService w)
        {
            // _logger = logger;
            _login = i;
            _worker = w;
        }


        // [HttpGet]
        // [Route("[action]")]
        // public IActionResult ifExist(string name,string password)
        // {
        //     var m = _logger.SifExist();
        //     if (m)
        //         return Ok();
        //     return NotFound();
        // }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<string> Login(string name, string password)
        {

            var dt = DateTime.Now;
            Console.WriteLine("check ");
            _worker.SWputHours(105,10);
            if (!_login.ifExist(name, password))
            {
                Console.WriteLine("in if 😒");
                return Unauthorized();
            }
            Console.WriteLine("not in if👍👌👍");
            // return Ok();
            // var worker1 = _worker.GetWorker(name);
            var worker1 = _worker.SWGetByName(name);

            var claims = new List<Claim>{
                new Claim("role", worker1.Role)
            };
            
            var token = LoginService.GetToken(claims);

            return new OkObjectResult(LoginService.WriteToken(token));
        }

        // private bool isExist(string name, string password)
        // {
        //     throw new NotImplementedException();
        // }

        //     [HttpPost]
        //     [Route("[action]")]
        //     [Authorize(Policy = "Admin")]
        //     public IActionResult GenerateBadge(Agent Agent)
        //     {

        //         var claims = new List<Claim>
        //   {
        //       new Claim("role", "Agent"),
        //       new Claim("ClearanceLevel", Agent.ClearanceLevel.ToString()),
        //   };

        //         var token = LoginService.GetToken(claims);

        //         return new OkObjectResult(LoginService.WriteToken(token));
        //     }
    }
}