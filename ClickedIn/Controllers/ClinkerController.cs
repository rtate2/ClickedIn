using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClickedIn.Controllers
{
    [Route("api/clinker")]
    [ApiController]
    public class ClinkerController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddClinker(Clinker clinkerToAdd)
        {
            return NotFound("In progress");
        }

        [HttpGet("{Id}")]
        public IActionResult GetClinker(int Id)
        {
            return NotFound("In progress");
        }

        [HttpGet("{Interest}")]
        public IActionResult GetClinkerByInterest(string Interest)
        {
            return NotFound("In progress");
        }
    }
}