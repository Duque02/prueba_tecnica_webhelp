using System;
using Webhelp.PruebaTecnica.Domain.Models;


namespace Webhelp.PruebaTecnica.Domain.Repositories
{
	public interface IAppointmentRepository
	{
		public Task<ICollection<Appointment>> GetAppointments(int stateId, DateOnly date);

		public Task<Appointment> UpdateAppointments(int appointmentId, int patientId, int stateId);
	}
}

