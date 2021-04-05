using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }


        [HttpPost("carttovalidate")]
        public IActionResult CartToValidate(Cart cart)
        {
            var res = _cartService.CartToValidate(cart);
            if (res.Success)
                return Ok(res);
            return BadRequest(res);
        }
    }
}
