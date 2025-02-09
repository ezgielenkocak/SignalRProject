using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Packaging.Signing;
using SignalRWebUi.Dtos.TestimonialDtos;
using System.Text;

namespace SignalRWebUi.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44364/api/Testimonial");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(value);
            }
            return View();

        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]  
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto dto)
        {
            var client=_httpClientFactory.CreateClient();   
            var jsonData= JsonConvert.SerializeObject(dto); 
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage =await  client.PutAsync("https://localhost:44364/api/Testimonial",content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");   
            }
            return View();
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44364/api/Testimonial/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage =await client.GetAsync($"https://localhost:44364/api/Testimonial/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();    
                var values=JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto dto)
        {
            var client=_httpClientFactory.CreateClient();   
            var jsonData =JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8, "application/json");
            var responseMessage =await  client.PutAsync("https://localhost:44364/api/Testimonial", content);
            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");   
            }
            return View();
        }
    }
}
