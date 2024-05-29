using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSAip.DTO;
using SSAip.Interfaces;
using SSAip.Models;
using System.Collections.Generic;

namespace SSAip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository repository;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            repository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllProduct")]
        public IActionResult GetAllProduct() {
           var list = _mapper.Map<List<ProductDTO>>( repository.GetAll());

            if(!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(list);

        }

        [HttpGet]
        [Route("GetPByID")]
        public IActionResult GetProductByID(string id)
        {
            var product = _mapper.Map<ProductDTO>(repository.GetProductByID(id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(product);

        }

        [HttpGet]
        [Route("GetProductByName")]
        public IActionResult GetAllProduct(string name)
        {
            var list = _mapper.Map<List<ProductDTO>>(repository.GetProductByName(name));

            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(list);

        }
        [HttpGet]
        [Route("GetProductByCategory")]
        public IActionResult GetProductByCategory(int idcategory)
        {
            var list = _mapper.Map<List<ProductDTO>>(repository.GetProductByCategory(idcategory));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(list);

        }
        [HttpGet]
        [Route("GetProductBrand")]
        public IActionResult GetProductByBrand(int idbrand)
        {
            var list = _mapper.Map<List<ProductDTO>>(repository.GetProductByBrand(idbrand));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(list);

        }

        [HttpPost]
        [Route("PostProduct")]
        public IActionResult PostProduct(ProductDTO newPoduct)
        {
            var addProduct  = repository.Add(newPoduct);
            if (addProduct == false)
            {
                return BadRequest(ModelState);
            }
            return Ok();

        }

        [HttpPut]
        [Route("PutProduct")]
        public IActionResult PutProduct(ProductDTO newPoduct)
        {
            var updateProduct = repository.Update(newPoduct);
            if (updateProduct==false)
            {
                return BadRequest(ModelState);
            }
            return Ok();

        }
        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(string id)
        {
            var deleteProduct = repository.Delete(id);
            if (deleteProduct==false)
            {
                return BadRequest(ModelState);
            }
            return Ok();

        }



    }
}
