using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coelsa.Business.ContactManager.Interface;
using Coelsa.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coelsa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactManager _contactService;

        public ContactsController(IContactManager contactService) => _contactService = contactService;



        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetContacts([FromQuery] ContactsParameters contactsParameters)
        {
            return _contactService.GetAllContactsPaging(contactsParameters).ToList();
        }


        //[HttpGet]
        //public ActionResult<IEnumerable<Contact>> GetContacts()
        //{
        //    return _contactService.GetAllContacts().ToList();
        //}


        [HttpGet("{id}")]
        public ActionResult<Contact> GetContactItem(int id)
        {
            var contactItem = _contactService.GetContactbyId(id);

            if (contactItem == null)
            {
                return NotFound();
            }
            return contactItem;
        }


        // POST: api/contact
        [HttpPost]
        public ActionResult<Contact> PostContactItem(Contact Contact)
        {
            _contactService.AddContact(Contact);

            return CreatedAtAction(
                "GetContactItem",
                new Contact { Id = Contact.Id },
                Contact);
        }


        // PUT: api/contacts/1
        [HttpPut("{id}")]
        public ActionResult<Contact> PutContactItem(int id, Contact Contact)
        {
            Contact contactItem;
            if (id != Contact.Id)
            {
                return BadRequest();
            }


            try
            {
                contactItem = _contactService.UpdateContact(Contact);
            }
            catch (Exception)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return contactItem;
        }


        // DELETE: api/contacts/1
        [HttpDelete("{id}")]
        public Contact DeleteContactItem(int id)
        {
            var ContactItem = _contactService.GetContactbyId(id);

            if (ContactItem == null)
            {
                return null;
            }

            var result = _contactService.DeleteContact(ContactItem);

            if (result == 1)
            {
                return ContactItem;
            }else 
            { 
                return null; 
            }
        }


        private bool UserExists(int id)
        {
            return _contactService.ContactExists(id);
        }
    }
}