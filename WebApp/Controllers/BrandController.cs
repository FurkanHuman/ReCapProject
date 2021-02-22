using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        readonly IBrandService _brantService;

        public BrandController(IBrandService brantService)
        {
            _brantService = brantService;
        }

        [HttpGet("Getall")]
        public IActionResult GetAll()
        {
            var result = _brantService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("Getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _brantService.GetById(Id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brantService.Add(brand);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brantService.Delete(brand);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brantService.Update(brand);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

    }
}
