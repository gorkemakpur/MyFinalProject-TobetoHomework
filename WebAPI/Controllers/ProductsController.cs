using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results.ResultType;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //controllerin api olduğunu belirtir
    [Route("api/[controller]")] //nasıl istek atılacak
    [ApiController] //bu class bir controller görevi görecek
    //api isimlendirmeleri çoğul verilir
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if(result.Success)
            {
                //ok-->200 başarılı
                //işlem başarılıysa datayı döndür yada sadece resultu döndür
                return Ok(result);
            }
            //badrequest hata 
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }




    }
}
