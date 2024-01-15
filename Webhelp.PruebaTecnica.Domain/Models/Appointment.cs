using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webhelp.PruebaTecnica.Domain.Models
{
	public class Appointment
	{
		public int AppointmentId { get; set; }

        public string Date { get; set; }

        public string Hours { get; set; }

        public int? PatientId { get; set; }

        public int StateID { get; set; }
	}
}

