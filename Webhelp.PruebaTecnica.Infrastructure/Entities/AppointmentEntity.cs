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
        public int AppointmentId { get; set; }

        public DateOnly Date {  get; set; }

        public TimeOnly Time { get; set; }

        [ForeignKey("Patient")]
        public int? PatientId { get; set; }

        [ForeignKey("AppointmentState")]
        public int StateId { get; set; }

        public DateTime? LastUpdate { get; set; }

        public AppointmentStateEntity AppointmentState { get; set; }

        public PatientEntity? Patient { get; set; }
    }
}
