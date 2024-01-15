using Webhelp.PruebaTecnica.Domain.Repositories;
using Webhelp.PruebaTecnica.Domain.Models;
using Webhelp.PruebaTecnica.Infrastructure.Entities;
using Webhelp.PruebaTecnica.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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
			Patient? patient = await _dBContext.PatientEntity
				.Where(item => item.PatientId == id)
				.Select(item => new Patient()
				{
					PatientId = item.PatientId,
					Name = item.Name,
					LastName = item.LastName,
					DocumentTypeId = item.DocumentTypeId,
					DocumentType = item.DocumentType.Description,
					Document = item.Document
				})
				.FirstOrDefaultAsync();

			if (patient != null)
			{
				return patient;
			}
			else
			{
				throw new NotFoundException();
			}
        }
    }
}

