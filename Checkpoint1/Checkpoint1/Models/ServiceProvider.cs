using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Checkpoint1.Models
{
    public class ServiceProvider
    {
        public ServiceProvider()
        {
            ServiceProviderId = Guid.NewGuid();
        }
        
        public Guid ServiceProviderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public ICollection<Appointment> Appointments { get; set; }
    }
}