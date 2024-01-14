using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webhelp.PruebaTecnica.API.Services;
using Webhelp.PruebaTecnica.Domain.Models;
using Webhelp.PruebaTecnica.Domain.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webhelp.PruebaTecnica.API.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private IPatientSevice _service;

        public PatientController(IPatientSevice service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Patient patient = await _service.GetPatients(id);
                return Ok(patient);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}

