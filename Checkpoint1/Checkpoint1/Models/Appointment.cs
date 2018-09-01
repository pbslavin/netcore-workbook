using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkpoint1.Models
{
    public class Appointment
    {
        public enum Days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };

        public enum Times { Nine, Ten, Eleven, Noon, One, Two, Three, Four, Five };

        public Appointment()
        {
            AppointmentId = Guid.NewGuid();
        }
        
        public Guid AppointmentId { get; set; }
        public Days Day { get; set; }
        public Times Time { get; set; }

        public Guid ServiceProviderId { get; set; }
        public ServiceProvider ServiceProvider { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}