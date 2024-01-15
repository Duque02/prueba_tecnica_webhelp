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

            ICollection<Appointment> appointments = await _repository.GetAppointments(stateId, queryDate);
            return appointments;
        }
		public async Task<Appointment> AppointmentUpdate(UpdateAppointmentRequest value)
		{
			var stateId = AppointmentStates.Pending;
			Appointment appointment = await _repository.UpdateAppointments(value.appointmentId, value.patientCode, stateId);
			return appointment;
        }

        public async Task<ICollection<Appointment>> GetByDate(string? date)
		{
            if (string.IsNullOrEmpty(date))
            {
                throw new BadRequestException();
            }

            if (!DateOnly.TryParse(date, out DateOnly queryDate))
            {
                throw new BadRequestException();
            }

            ICollection<Appointment> appointments = await _repository.GetByDate(queryDate);

            DateOnly today = DateOnly.FromDateTime(DateTime.Today);

            if (queryDate == today) {
                appointments = appointments.Where(item => item.StateID == AppointmentStates.Pending).ToList();
            }

            return appointments;
        }

    }
}

