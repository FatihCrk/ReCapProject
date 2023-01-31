using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            //Dependency Chain -- Bağımlılık zinciri.
            var result = _carService.GetAll();
            //Parametre sonucu başarılı ise result.* ile sonucu mesaj veya data veya başarılı mı bilgisini gönderebiliriz.
            //sadece result ise hepsini gönderir.
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }




    }
}
