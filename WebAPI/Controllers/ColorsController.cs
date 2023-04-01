using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {

        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            //Dependency Chain -- Bağımlılık zinciri.
            var result = _colorService.GetAll();
            //Parametre sonucu başarılı ise result.* ile sonucu mesaj veya data veya başarılı mı bilgisini gönderebiliriz.
            //sadece result ise hepsini gönderir.
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpPost("add")]
        public IActionResult Add(Color color)
        {

            var result = _colorService.Add(color);

            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);


        }



    }
}
