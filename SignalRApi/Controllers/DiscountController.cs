using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var value=_mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);   
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(new Discount
            {
                Amount = createDiscountDto.Amount,
                Description=createDiscountDto.Description,
                ImageUrl=createDiscountDto.ImageUrl,
                Title=createDiscountDto.Title,
            });
            return Ok("İndirim eklendi");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount
            {
                DiscountID=updateDiscountDto.DiscountID,
                Description=updateDiscountDto.Description,
                Amount=updateDiscountDto.Amount,    
                ImageUrl =updateDiscountDto.ImageUrl,
                Title= updateDiscountDto.Title, 
            });
            return Ok("İndirim Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            _discountService.TDelete(value);
            return Ok("İndirim silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value=_discountService.TGetByID(id);
            return Ok(value);   
        }
    }
} 
