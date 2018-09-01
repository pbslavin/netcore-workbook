using System;
using System.ComponentModel.DataAnnotations;

namespace Checkpoint1.Models
{
    public class Appointment
    {
        public enum Days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };

        public enum Times { Nine, Ten, Eleven, Noon, One, Two, Three, Four, Five };

        public Appointment()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public Days Day { get; set; }
        public Times Time { get; set; }

        public Guid ServiceProviderId { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}