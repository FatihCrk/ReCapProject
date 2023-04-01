﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Entities.Concrete;
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
            Thread.Sleep(2000);
            //Dependency Chain -- Bağımlılık zinciri.
            var result = _carService.GetAll();
            //Parametre sonucu başarılı ise result.* ile sonucu mesaj veya data veya başarılı mı bilgisini gönderebiliriz.
            //sadece result ise hepsini gönderir.
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }



        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);
           


            var result = _carService.Add(car);
            //Parametre sonucu başarılı ise result.* ile sonucu mesaj veya data veya başarılı mı bilgisini gönderebiliriz.
            //sadece result ise hepsini gönderir.
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbybrand")]
        public IActionResult GetByBrandId(int brandId) { 
            var result  = _carService.GetAllByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpGet("getbycolor")]
        public IActionResult GetByColorId(int colorId)
        {
            var result = _carService.GetAllByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getcardetails")]
        public IActionResult GetCustomerDetails()
        {
            var result = _carService.GetAllByCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}
