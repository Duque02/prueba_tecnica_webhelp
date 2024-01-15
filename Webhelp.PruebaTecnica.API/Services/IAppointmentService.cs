using System;
using Webhelp.PruebaTecnica.API.RequestModels;
using Webhelp.PruebaTecnica.Domain.Models;

namespace Webhelp.PruebaTecnica.API.Services
{
	public interface IAppointmentService
	{
        public Task<ICollection<Appointment>> GetAppointment(int stateId, string? date);

        public Task<Appointment> AppointmentUpdate(UpdateAppointmentRequest value);

        public Task<ICollection<Appointment>> GetByDate(string? date);
    }
}


