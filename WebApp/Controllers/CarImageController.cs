using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        readonly ICarImageService _carImageService;

        public CarImageController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("GetImagesByCarId")]
        public IActionResult GetImagesByCarId(int id)
        {
            var result = _carImageService.GetImagesByCarId(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult AddAsync([FromForm(Name = ("Image"))] IFormFile[] file, [FromForm] CarImage carImage)
        {
            var res = _carImageService.Add(file, carImage);
            if (res.Success)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int id)
        {
            var carImage = _carImageService.GetById(id);
            var result = _carImageService.Delete(carImage.Data);

            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(file, carImage);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
