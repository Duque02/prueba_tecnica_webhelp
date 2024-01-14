using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Webhelp.PruebaTecnica.Infrastructure.Entities
{
    [Table("Patients")]
    internal class PatientEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        [ForeignKey("DocumentType")]
        public int DocumentTypeId { get; set; }

        public string Document { get; set; }

        public DocumentTypeEntity DocumentType { get; set; }

        public ICollection<AppointmentEntity> Appointments { get; set; }
    }
}
