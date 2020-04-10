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
        public IActionResult GetClinkerById(int id)
        {
            var result = _repository.GetClinkerById(id);
            return Ok(result);
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

        [HttpPost("clinker/{clinkerId}/homie/{homieId}")]
        public IActionResult AddHomie(int clinkerId, int homieId)
        {
            var clinker = _repository.AddHomies(clinkerId, homieId);
            return Ok(clinker);
        }

        [HttpPost("clinker/{clinkerId}/enemy/{enemyId}")]
        public IActionResult AddEnemy(int clinkerId, int enemyId)
        {
            var clinker = _repository.AddEnemy(clinkerId, enemyId);
            return Ok(clinker);
        }
    }
}