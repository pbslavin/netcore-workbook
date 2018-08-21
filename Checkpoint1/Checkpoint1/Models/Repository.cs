using System.Collections.Generic;
using System.Linq;

namespace Checkpoint1.Models
{
    public class Repository
    {
        private int[] _availableTimes = { 8, 9, 10, 11, 12, 1, 2, 3, 4, 5 };

        public List<Customer> Customers { get; } = new List<Customer>();
        public List<ServiceProvider> ServiceProviders { get; } = new List<ServiceProvider>();
        public List<Appointment> Appointments { get; } = new List<Appointment>();

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public void AddServiceProvider(ServiceProvider serviceProvider)
        {
            ServiceProviders.Add(serviceProvider);
        }

        public void AddAppointment(Appointment appointment)
        {
            Appointments.Add(appointment);
        }

        public void BookAppointment(Appointment appointment)
        {
            List<Appointment> appointments = this.Appointments;
            bool cflag = false;
            bool sflag = false;
            bool isEmpty = !this.Appointments.Any();
            if (!isEmpty)
            {
                //var isInvalidAppointment = appointments.Any(a => ((appointment.CustomerFullName == a.CustomerFullName
                //    || appointment.ServiceProviderFullName == a.ServiceProviderFullName)
                //    && appointment.Time == a.Time)
                //    || !_availableTimes.Contains(appointment.Time))
                //        );
                //if (isInvalidAppointment)
                //    return; // throw expection?

                foreach (Appointment a in appointments)
                {

                    if (((appointment.CustomerFullName == a.CustomerFullName 
                        || appointment.ServiceProviderFullName == a.ServiceProviderFullName) 
                        && appointment.Time == a.Time)
                        || !_availableTimes.Contains(appointment.Time))
                    {
                        return;
                    }
                }
            }
            else if (!_availableTimes.Contains(appointment.Time))
            {
                return;
            }
            //// isValidCustomer?
            //if (isInvalidCustomer(appointment.CustomerFullName))
            //{
            //    // throw invalidcustomerexception
            //}
            foreach (Customer c in this.Customers)
            {
                if (appointment.CustomerFullName == c.FullName)
                {
                    cflag = true;
                    break;
                }
            }
            if (!cflag)
                return;
            foreach (ServiceProvider s in this.ServiceProviders)
            {
                if (appointment.ServiceProviderFullName == s.FullName)
                {
                    sflag = true;
                    break;
                }
            }
            if (!sflag)
                return;
           this.AddAppointment(appointment);
        }

        //private bool IsInvalidCustomer(string fullName)
        //{
        //    return !this.Customers.Any(c => c.FirstName == fullName);
        //}
    }
}