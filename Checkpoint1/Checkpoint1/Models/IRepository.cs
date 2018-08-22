using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint1.Models
{
    public interface IRepository
    {
        List<Customer> Customers { get; }
        List<ServiceProvider> ServiceProviders { get; }
        List<Appointment> Appointments { get; set; }

        void AddCustomer(Customer customer);

        void AddServiceProvider(ServiceProvider serviceProvider);

        void AddAppointment(Appointment appointment);

        void BookAppointment(Appointment appointment);
    }
}
