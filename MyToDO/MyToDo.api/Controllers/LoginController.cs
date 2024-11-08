using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using MyToDo.api.Context;
using MyToDo.api.Service;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;
using System.Formats.Asn1;

namespace MyToDo.api.Controllers
{
    /// <summary>
    /// 备忘录控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")] //路由 
    public class LoginController : ControllerBase
    {
        private readonly ILoginService service;

        public LoginController(ILoginService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<ApiResponse> Register([FromBody] UserDto userDto) => await service.Register(userDto);

        [HttpGet]
        public async Task<ApiResponse> Login(string account,string password)=> await service.LoginAsync(account,password);


    }
}
