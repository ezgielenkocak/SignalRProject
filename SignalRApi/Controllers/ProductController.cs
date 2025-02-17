using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, IMapper mapper, ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product
            {
                ProductStatus = createProductDto.ProductStatus,
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Price = createProductDto.Price,
                ProductName = createProductDto.ProductName,
                CategoryId=createProductDto.CategoryID
                
            });
            return Ok("Product eklendi");
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var value= _productService.TProductCount();
            return Ok(value);
        }
        [HttpGet("ProductCountByHamburger")]
        public IActionResult ProductCountByHamburger()
        {
            var value = _productService.ProductCountByCategoryNameHamburger();
            return Ok(value);
        }
        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByDrink()
        {
            var value = _productService.ProductCountByCategoryNameDrink();
            return Ok(value);
        }
        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());  
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);   
        }
        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            var value=_productService.TProductNameByMaxPrice(); 
            return Ok(value);   
        }
        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            var value = _productService.TProductNameByMinPrice();
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product
            {
                ProductID=updateProductDto.ProductID,
                ProductStatus = updateProductDto.ProductStatus,
                Description=updateProductDto.Description,   
                ImageUrl=updateProductDto.ImageUrl,
                Price=updateProductDto.Price,
                ProductName=updateProductDto.ProductName,
                CategoryId=updateProductDto.CategoryID  

            });
            return Ok("Product Güncellendi");
         }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(value);   
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Product Silindi");
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoryDto
            {
                Description=y.Description,
                CategoryName=y.Category.CategoryName,
                ImageUrl=y.ImageUrl,
                Price=y.Price,
                ProductID=y.ProductID,
                ProductName =y.ProductName,
                ProductStatus=y.ProductStatus
            });
            return Ok(values);

        }

        [HttpGet("ProductAvgPriceByHamburger")]
        public IActionResult ProductAvgPriceByHamburger()
        {
            var context = new SignalRContext();
            var value = _productService.TProductAvgPriceByHamburger();
            return Ok(value);
        }
    }
}
