using Webhelp.PruebaTecnica.Domain.Repositories;
using Webhelp.PruebaTecnica.Domain.Models;
using Webhelp.PruebaTecnica.Infrastructure.Entities;
using Webhelp.PruebaTecnica.Domain.Exceptions;
using System;
using Microsoft.EntityFrameworkCore;

namespace Webhelp.PruebaTecnica.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly MedicalCenterDBContext _dBContext;

        public AppointmentRepository(MedicalCenterDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<ICollection<Appointment>> GetAppointments(int stateId, DateOnly date)
        {
            List<Appointment> appointments = await _dBContext.AppointmentEntity
                .Where(item => item.StateId == stateId && item.Date == date)
                .Select(item => new Appointment()
                {
                    AppointmentId = item.AppointmentId,
                    Date = item.Date.ToString(),
                    Hours = item.Time.ToString(),
                    PatientId = item.PatientId,
                    StateID = item.StateId
                })
                .ToListAsync();

            return appointments;
        }

        public async Task<Appointment> UpdateAppointments(int appointmentId, int patientId, int stateId)
        {
            AppointmentEntity? appointment = await _dBContext.AppointmentEntity
                .Where(item => item.AppointmentId == appointmentId)
                .FirstOrDefaultAsync();

            if(appointment != null)
            {
                appointment.StateId = stateId;
                appointment.PatientId = patientId;
                appointment.LastUpdate = DateTime.Now;

                _dBContext.AppointmentEntity.Update(appointment);
                await _dBContext.SaveChangesAsync();

                return new Appointment
                {
                    AppointmentId = appointment.AppointmentId,
                    Date = appointment.Date.ToString(),
                    Hours = appointment.Time.ToString(),
                    PatientId = appointment.PatientId,
                    StateID = appointment.StateId,
                    LastUpdate = appointment.LastUpdate.ToString() ?? ""

                };
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}


