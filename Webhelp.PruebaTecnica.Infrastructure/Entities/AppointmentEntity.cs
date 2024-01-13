using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webhelp.PruebaTecnica.Infrastructure.Entities
{
    [Table("Appointments")]
    internal class AppointmentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int AppointmentId { get; set; }
        DateOnly Date {  get; set; }
        TimeOnly Time { get; set; }
        [ForeignKey("Patient")]
        int? PatientId { get; set; }
        [ForeignKey("AppointmentState")]
        int StateId { get; set; }
        DateTime LastUpdate { get; set; }

        AppointmentStateEntity AppointmentState { get; set; }
        PatientEntity? Patient { get; set; }
    }
}
