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
        int StateId { get; set; }
        string Description { get; set; }
        
        ICollection<AppointmentEntity> Appointments { get; set; }
    }
}
