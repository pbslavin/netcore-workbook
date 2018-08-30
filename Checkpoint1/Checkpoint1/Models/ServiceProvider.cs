using System;
using System.ComponentModel.DataAnnotations;

namespace Checkpoint1.Models
{
    public class ServiceProvider
    {
        public ServiceProvider()
        {
            Id = Guid.NewGuid();
        }
        
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}