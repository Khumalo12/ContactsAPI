using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsAPI.Model;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public ContactController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        [HttpGet]
        [Route("Contacts")]
        public async Task<IActionResult> GetContacts(int phonebookId)
        {
            var response = await _repoWrapper.Contact.GetContacts(phonebookId);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("SearchContacts")]

        public async Task<IActionResult> SearchContacts(int phonebookId, string name)
        {
            var response = await _repoWrapper.Contact.GetContacts(phonebookId, name);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateContacts")]
        public async Task<IActionResult> CreateContacts([FromBody] Entry content)
        {
            try
            {
                if (content == null)
                {
                    return BadRequest("content object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                _repoWrapper.Contact.PostContacts(content.name, content.phonenumber, content.phonebook_id);
                await _repoWrapper.SaveAsync();

                return Ok(content);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}