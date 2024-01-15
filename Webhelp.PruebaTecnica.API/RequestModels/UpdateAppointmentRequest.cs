using System;
namespace Webhelp.PruebaTecnica.API.RequestModels
{
	public class UpdateAppointmentRequest
	{
		public int appointmentId { get; set; }

		public int patientCode { get; set; }
	}
}

