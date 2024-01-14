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
    [Index(nameof(Document), IsUnique = true)]
    internal class PatientEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int PatientId { get; set; }

        string Name { get; set; }

        string LastName { get; set; }

        [ForeignKey("DocumentType")]
        int DocumentTypeId { get; set; }

        string Document { get; set; }

       DocumentTypeEntity DocumentType { get; set; }

        ICollection<AppointmentEntity> Appointments { get; set; }
    }
}
