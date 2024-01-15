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
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? date)
        {
            try
            {
                ICollection<Appointment> appointments = await _service.GetAppointment(1, date);

                return Ok(new {
                    results = appointments
                });
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

