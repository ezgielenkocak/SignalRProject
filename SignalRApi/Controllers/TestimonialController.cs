using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial
            {
                Comment= createTestimonialDto.Comment,
                ImageUrl= createTestimonialDto.ImageUrl,
                Name= createTestimonialDto.Name,
                Status= createTestimonialDto.Status,
                Title= createTestimonialDto.Title,
                
            });
            return Ok("Testimonial Eklendi");
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var value=_mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial
            {
                TestimonialID= updateTestimonialDto.TestimonialID,
                Status= updateTestimonialDto.Status,
                Comment= updateTestimonialDto.Comment,
                ImageUrl=updateTestimonialDto.ImageUrl,
                Name = updateTestimonialDto.Name,
                Title= updateTestimonialDto.Title,
            });
            return Ok("Tesimonial Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value=_testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return Ok("Testimonial silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            return Ok(value);
        }
    }
}
