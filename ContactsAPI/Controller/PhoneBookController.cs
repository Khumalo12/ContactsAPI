using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public PhoneBookController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhoneBook(string phonebook)
        {
            var response = await _repoWrapper.Phonebook.GetPhonebook(phonebook);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}