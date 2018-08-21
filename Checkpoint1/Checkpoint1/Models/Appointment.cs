using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkpoint1.Models
{
    public class Appointment
    {
        public Appointment()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string ServiceProviderFullName { get; set; }

        public string CustomerFullName { get; set; }

        public string Day { get; set; }

        public int Time { get; set; }


    }
}