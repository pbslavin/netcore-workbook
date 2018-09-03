using Checkpoint1.Data;
using System.Collections.Generic;

namespace Checkpoint1.Models
{
    public interface IAppointmentBookingService
    {
        bool BookAppointment(Appointment appointment, ApplicationContext context);
    }
}