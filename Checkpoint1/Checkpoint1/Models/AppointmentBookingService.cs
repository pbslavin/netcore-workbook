using System;
using System.Collections.Generic;
using System.Linq;
using Checkpoint1.Data;

namespace Checkpoint1.Models
{
    public class AppointmentBookingService : IAppointmentBookingService
    {
        public class InvalidAppointmentException : Exception
        {
            public InvalidAppointmentException(string message) : base(message)
            {
            }
        }

        public bool BookAppointment(Appointment appointment, ApplicationContext context)
        {
            bool valid = false;
            List<Appointment> appointments = context.Appointments.ToList();

            // Appointment is invalid if either customer or service provider has an appointment at the same time on the same day.
            var isInvalidAppointment = appointments.Any(a => ((a.CustomerId == appointment.CustomerId
                || a.ServiceProviderId == appointment.ServiceProviderId)
                && a.Time == appointment.Time && a.Day == appointment.Day));
            if (isInvalidAppointment)
                throw new InvalidAppointmentException("Invalid Appointment");
            // if appointment is valid
            valid = true;
            return valid;
        }
    }
}