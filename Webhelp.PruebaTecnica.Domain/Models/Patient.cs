using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webhelp.PruebaTecnica.Domain.Models
{
	public class Patient
	{

        public int PatientId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int DocumentTypeId { get; set; }

        public string DocumentType { get; set; }

        public string Document { get; set; }
    }
}

