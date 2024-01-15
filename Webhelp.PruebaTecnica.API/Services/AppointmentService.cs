using System;
using Webhelp.PruebaTecnica.Domain.Models;
using Webhelp.PruebaTecnica.Domain.Repositories;
using Webhelp.PruebaTecnica.Domain.Exceptions;
using Webhelp.PruebaTecnica.API.RequestModels;

namespace Webhelp.PruebaTecnica.API.Services
{
	public class AppointmentService : IAppointmentService
	{
		private readonly IAppointmentRepository _repository;

		public AppointmentService(IAppointmentRepository repository)
		{
			_repository = repository;

		}
        public async Task<ICollection<Appointment>> GetAppointment(int stateId, string? date)
        {
			if (date == null)
			{
				throw new BadRequestException();
			}

            if (!DateOnly.TryParse(date, out DateOnly queryDate))
			{
				throw new BadRequestException();
			}

            ICollection<Appointment> appointment = await _repository.GetAppointments(stateId, queryDate);
            return appointment;
        }
		public async Task<Appointment> AppointmentUpdate(UpdateAppointmentRequest value)
		{
			var stateId = 2;
			Appointment appointment = await _repository.UpdateAppointments(value.appointmentId, value.patientCode, stateId);
			return appointment;
        }



    }
}

