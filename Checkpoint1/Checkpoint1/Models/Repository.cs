﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkpoint1.Models
{
    public class Repository : IRepository
    {
        public List<Customer> Customers { get; } = new List<Customer>();
        public List<ServiceProvider> ServiceProviders { get; } = new List<ServiceProvider>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public class InvalidAppointmentException : Exception
        {
            public InvalidAppointmentException(string message) : base(message)
            {
            }
        }

        ////public class InvalidCustomerException : Exception
        ////{
        ////    public InvalidCustomerException(string message) : base(message)
        ////    {
        ////    }
        ////}

        ////public class InvalidServiceProviderException : Exception
        ////{
        ////    public InvalidServiceProviderException(string message) : base(message)
        ////    {
        ////    }
        ////}

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
            appointment.Customer = Customers.Find(c => c.CustomerId == appointment.CustomerId);
            appointment.ServiceProvider = ServiceProviders.Find(s => s.ServiceProviderId == appointment.ServiceProviderId);
            Appointments.Add(appointment);
            Appointments = Appointments.OrderBy(a => a.Day).ThenBy(a => a.Time).ToList();
        }

        public void BookAppointment(Appointment appointment)
        {
            List<Appointment> appointments = this.Appointments;

            // Appointment is invalid if either customer or service provider has an appointment at the same time on the same day.
            var isInvalidAppointment = appointments.Any(a => ((a.CustomerId == appointment.CustomerId
                || a.ServiceProviderId == appointment.ServiceProviderId)
                && a.Time == appointment.Time && a.Day == appointment.Day));
            if (isInvalidAppointment)
                throw new InvalidAppointmentException("Invalid Appointment");

            ////var isValidCustomer = Customers.Any(c => c.FullName == appointment.Customer.FullName);
            ////if (!isValidCustomer)
            ////{
            ////    throw new InvalidCustomerException("Invalid Customer");
            ////}

            ////var isValidServiceProvider = ServiceProviders.Any(c => c.FullName == appointment.ServiceProvider.FullName);
            ////if (!isValidServiceProvider)
            ////{
            ////    throw new InvalidServiceProviderException("Invalid Service Provider");
            ////}
            // if all is valid, save appointment to Appointments list.
            this.AddAppointment(appointment);
        }
    }
}