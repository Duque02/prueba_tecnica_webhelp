using System;
using Webhelp.PruebaTecnica.Domain.Models;

namespace Webhelp.PruebaTecnica.Domain.Repositories
{
	public interface IPatientRepository
	{
		public Task<Patient> ConsultPatient(int id);
	}
}

