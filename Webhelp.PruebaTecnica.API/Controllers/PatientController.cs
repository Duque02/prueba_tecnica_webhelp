using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webhelp.PruebaTecnica.API.Services;
using Webhelp.PruebaTecnica.Domain.Models;
using Webhelp.PruebaTecnica.Domain.Exceptions;
using Webhelp.PruebaTecnica.API.Authentication;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webhelp.PruebaTecnica.API.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private IPatientSevice _service;
        private readonly IAuthenticationManager _authManager;

        public PatientController(IPatientSevice service, IAuthenticationManager authenticationManager)
        {
            _service = service;
            _authManager = authenticationManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromHeader(Name = "ApiKey")] string? apiKey, int id)
        {
            try
            {
                _authManager.validateApiKey(apiKey);

                Patient patient = await _service.GetPatients(id);
                return Ok(patient);
            }
            catch (AuthenticationException)
            {
                return Unauthorized();
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

