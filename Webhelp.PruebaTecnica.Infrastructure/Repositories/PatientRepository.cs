using Webhelp.PruebaTecnica.Domain.Repositories;
using Webhelp.PruebaTecnica.Domain.Models;
using Webhelp.PruebaTecnica.Infrastructure.Entities;
using System;
using Webhelp.PruebaTecnica.Domain.Exceptions;

namespace Webhelp.PruebaTecnica.Infrastructure.Repositories
{
	public class PatientRepository : IPatientRepository
	{
		private readonly MedicalCenterDBContext _dBContext;

		public PatientRepository(MedicalCenterDBContext dBContext)
		{
			_dBContext = dBContext;
		}

        public async Task<Patient> ConsultPatient(int id)
        {
			PatientEntity? patient = await _dBContext.PatientEntity.FindAsync(id);

			if (patient != null)
			{
				return new Patient()
				{
					PatientId = patient.PatientId,
					Name = patient.Name,
					LastName = patient.LastName,
					DocumentTypeId = patient.DocumentTypeId,
					Document = patient.Document
				};
			}
			else
			{
				throw new NotFoundException();
			}
        }
    }
}

