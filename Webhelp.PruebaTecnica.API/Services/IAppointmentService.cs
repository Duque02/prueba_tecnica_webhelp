using System;
using Webhelp.PruebaTecnica.Domain.Models;

namespace Webhelp.PruebaTecnica.API.Services
{
	public interface IAppointmentService
	{
            public Task<ICollection<Appointment>> GetAppointment(int stateId, string? date);
    }
}


