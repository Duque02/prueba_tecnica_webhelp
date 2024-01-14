using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webhelp.PruebaTecnica.Infrastructure.Entities
{
    [Table("AppointmentStates")]
    internal class AppointmentStateEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }

        public string Description { get; set; }

        public ICollection<AppointmentEntity> Appointments { get; set; }
    }
}
