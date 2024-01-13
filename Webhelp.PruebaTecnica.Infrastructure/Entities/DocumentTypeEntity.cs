﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webhelp.PruebaTecnica.Infrastructure.Entities
{
    [Table("DocumentTypes")]
    internal class DocumentTypeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       int DocumentId { get; set; }
       string Description { get; set; }

        ICollection<PatientEntity> Patients { get; set; }
    }
}
