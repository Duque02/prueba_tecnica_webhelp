using System;
using Webhelp.PruebaTecnica.Domain.Models;
using Webhelp.PruebaTecnica.Domain.Repositories;

namespace Webhelp.PruebaTecnica.API.Services
{
	public class PatientService : IPatientSevice
	{
		private IPatientRepository _repository;

		public PatientService(IPatientRepository repository)
		{
			_repository = repository;
		}

		public async Task<Patient> GetPatients(int id)
		{
			Patient patient = await _repository.ConsultPatient(id);
			return patient;
		}
	}
}

