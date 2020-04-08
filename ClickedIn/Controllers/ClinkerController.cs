using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClickedIn.DataAccess;
using ClickedIn.Models;

namespace ClickedIn.Controllers
{
    [Route("api/clinker")]
    [ApiController]
    public class ClinkerController : ControllerBase
    {
        ClinkerRepository _repository = new ClinkerRepository();

        [HttpPost]
        public IActionResult AddClinker(Clinker clinkerToAdd)
        {
            _repository.AddClinker(clinkerToAdd);

            return Created("", clinkerToAdd);  
        }

        [HttpGet("{Id}/id")]
        public IActionResult GetClinker(int id)
        {
            return NotFound("In progress");
        }

        [HttpGet("{Interest}/interest")]
        public IActionResult GetClinkerByInterest(string interestString)
        {
             var testing = _repository.GetClinkersByInterest(interestString);

            return NotFound(testing);
        }

        [HttpGet]
        public IActionResult GetAllClinkers()
        {
            var allClinkers = _repository.GetClinkers();

            return Ok(allClinkers);
        }
    }
}