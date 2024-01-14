using System;
using Webhelp.PruebaTecnica.Domain.Models;

namespace Webhelp.PruebaTecnica.API.Services
{
	public interface IPatientSevice
	{
		public Task<Patient> GetPatients(int id);
	}
}

