using Checkpoint1.Models;
using Checkpoint1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Checkpoint1.Tests.Controllers
{
    public class MyMockedRepository : IRepository
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<ServiceProvider> ServiceProviders { get; set; } = new List<ServiceProvider>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public class InvalidAppointmentException : Exception
        {
            public InvalidAppointmentException(string message) : base(message)
            {
            }
        }

        public class InvalidCustomerException : Exception
        {
            public InvalidCustomerException(string message) : base(message)
            {
            }
        }

        public class InvalidServiceProviderException : Exception
        {
            public InvalidServiceProviderException(string message) : base(message)
            {
            }
        }

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

            var isInvalidAppointment = appointments.Any(a => ((a.CustomerFullName == appointment.CustomerFullName
                || a.ServiceProviderFullName == appointment.ServiceProviderFullName)
                && a.Time == appointment.Time && a.Day == appointment.Day));
            if (isInvalidAppointment)
                throw new InvalidAppointmentException("Invalid Appointment");

            var isValidCustomer = Customers.Any(c => c.FullName == appointment.CustomerFullName);
            if (!isValidCustomer)
            {
                throw new InvalidCustomerException("Invalid Customer");
            }

            var isValidServiceProvider = ServiceProviders.Any(c => c.FullName == appointment.ServiceProviderFullName);
            if (!isValidServiceProvider)
            {
                throw new InvalidServiceProviderException("Invalid Service Provider");
            }
            this.AddAppointment(appointment);
        }
    }

    public class ControllerTests
    {
        [Fact]
        public void Customer_ShouldAddNewCustomer()
        {
            // Assemble
            var mockRepository = new MyMockedRepository();
            var customer = new Customer
            {
                FirstName = "Peter",
                LastName = "Slavin"
            };
            CustomerController controller = new CustomerController(mockRepository);

            // Act
            controller.Create(customer);

            // Assert
            Assert.NotEmpty(mockRepository.Customers);
        }

        [Fact]
        public void ServiceProvider_ShouldAddNewServiceProvider()
        {
            // Assemble
            var mockRepository = new MyMockedRepository();
            var serviceProvider = new ServiceProvider
            {
                FirstName = "Peter",
                LastName = "Slavin"
            };
            ServiceProviderController controller = new ServiceProviderController(mockRepository);

            // Act
            controller.Create(serviceProvider);

            // Assert
            Assert.NotEmpty(mockRepository.ServiceProviders);
        }

        [Fact]
        public void Appointment_ShouldDeleteAppointment()
        {
            // Assemble
            var mockRepository = new MyMockedRepository();
            var appointment = new Appointment
            {
                CustomerFullName = "Peter Slavin",
                ServiceProviderFullName = "Amy Taulman",
                Day = 0,
                Time = 0
            };
            mockRepository.AddAppointment(appointment);
            AppointmentController controller = new AppointmentController(mockRepository);

            // Act
            controller.Delete(appointment);

            // Assert
            Assert.Empty(mockRepository.Appointments);
        }
    }

    public class RepositoryTest
    {
        [Fact]
        public void Repository_ShouldBookAppointments()
        {
            // Assemble
            var mockRepository = new MyMockedRepository();
            var customer = new Customer
            {
                FirstName = "Peter",
                LastName = "Slavin"
            };
            mockRepository.AddCustomer(customer);

            var serviceProvider = new ServiceProvider
            {
                FirstName = "Amy",
                LastName = "Taulman"
            };
            mockRepository.AddServiceProvider(serviceProvider);

            var appointment = new Appointment
            {
                CustomerFullName = customer.FullName,
                ServiceProviderFullName = serviceProvider.FullName,
                Day = 0,
                Time = 0
            };

            // Act
            mockRepository.BookAppointment(appointment);

            // Assert
            Assert.NotEmpty(mockRepository.Appointments);
        }
    }
}