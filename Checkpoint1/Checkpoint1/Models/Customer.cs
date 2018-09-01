using System;
using System.ComponentModel.DataAnnotations;

namespace Checkpoint1.Models
{
    public class Customer
    {
        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }

        [Key]
        public Guid CustomerId { get; set; }
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