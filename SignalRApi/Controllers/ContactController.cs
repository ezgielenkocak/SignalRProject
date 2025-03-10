﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            
            var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.TAdd(new Contact()
            {
                FooterDescription= createContactDto.FooterDescription,
                Location= createContactDto.Location,
                Mail= createContactDto.Mail,    
                PhoneNumber= createContactDto.PhoneNumber,
            });
            return Ok("Contact eklendi");    
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return Ok("Contact silindi ");
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(new Contact
            {
                ContactID=updateContactDto.ContactID,
                FooterDescription= updateContactDto.FooterDescription,
                Location= updateContactDto.Location,    
                Mail= updateContactDto.Mail,    
                PhoneNumber = updateContactDto.PhoneNumber,     
            });
            return Ok("Contact Güncellendi");
        }
    }
}
