using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webhelp.PruebaTecnica.API.Services;
using Webhelp.PruebaTecnica.Domain.Models;
using Webhelp.PruebaTecnica.Domain.Exceptions;
using Webhelp.PruebaTecnica.API.RequestModels;
using Webhelp.PruebaTecnica.API.Authentication;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webhelp.PruebaTecnica.API.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private readonly IAuthenticationManager _authManager;
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service, IAuthenticationManager autManager)
        {
            _service = service;
            _authManager = autManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromHeader(Name = "ApiKey")] string? apiKey, [FromQuery] string? date)
        {
            try
            {
                _authManager.validateApiKey(apiKey);

                ICollection<Appointment> appointments = await _service.GetAppointment(AppointmentStates.Available, date);
                return Ok(new
                {
                    results = appointments
                });
            }
            catch (AuthenticationException)
            {
                return Unauthorized();
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST api/values
        [HttpPut]
        public async Task<IActionResult> Put([FromHeader(Name = "ApiKey")] string? apiKey, [FromBody] UpdateAppointmentRequest value)
        {
            try
            {
                _authManager.validateApiKey(apiKey);
                Appointment updateAppointment = await _service.AppointmentUpdate(value);
                return Ok(
                    updateAppointment
                );
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

        [HttpGet]
        [Route("GetbyDate")]
        public async Task<IActionResult> GetByDate([FromHeader(Name = "ApiKey")] string? apiKey, [FromQuery] string? date)
        {
            try
            {
                _authManager.validateApiKey(apiKey);

                ICollection<Appointment> appointments = await _service.GetByDate(date);
                return Ok(new
                {
                    results = appointments
                });
            }
            catch (AuthenticationException)
            {
                return Unauthorized();
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}