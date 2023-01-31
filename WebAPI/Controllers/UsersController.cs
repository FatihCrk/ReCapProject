using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }




        [HttpPost("add")]
        public IActionResult Add(User user)
        {

            //Dependency Chain -- Bağımlılık zinciri.
            var result = _userService.Add(user);
            //Parametre sonucu başarılı ise result.* ile sonucu mesaj veya data veya başarılı mı bilgisini gönderebiliriz.
            //sadece result ise hepsini gönderir.
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyuserid")]
        public IActionResult Get(int Id)
        {
            var result = _userService.GetByUserId(Id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPut]
        public IActionResult DeleteByUserId(User user)
        {
            var result = _userService.Delete(user);

            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


    }
}
