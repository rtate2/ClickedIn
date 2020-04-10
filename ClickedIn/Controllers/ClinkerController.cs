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

        [HttpGet("{interestString}/interest")]
        public IActionResult GetClinkersByInterest(string interestString)
        {
             var result = _repository.GetClinkersByInterest(interestString);

            if (result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound("There are no clinkers with this interest.");
        }

        [HttpGet("{serviceString}/service")]
        public IActionResult GetClinkersByServices(string serviceString)
        {
            var result = _repository.GetClinkersByServices(serviceString);

            if (result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound("There are no clinkers with the requested service.");
        }

        [HttpGet]
        public IActionResult GetAllClinkers()
        {
            var allClinkers = _repository.GetClinkers();

            return Ok(allClinkers);
        }

        [HttpPost("homie/{homieToAdd}")]
        public IActionResult AddHomie(Clinker homieToAdd)
        {
            var allHomies = _repository.AddHomies(homieToAdd);
            return Ok(allHomies);
        }

        [HttpPost("enemy/{enemyToAdd}")]
        public IActionResult AddEnemy(Clinker enemyToAdd)
        {
            var allEnemies = _repository.AddEnemy(enemyToAdd);
            return Ok(allEnemies);
        }
    }
}