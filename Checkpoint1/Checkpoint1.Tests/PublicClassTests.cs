using Checkpoint1.Models;
using Checkpoint1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Checkpoint1.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Checkpoint1.Tests.Controllers
{
    public class PublicClassTests
    {
        [Fact]
        public async Task Customer_ShouldCreateNewCustomerAsync()
        {
            // Assemble
            var context = new ApplicationContext(DbAssembly().Options);
            var customerController = new CustomerController(context, new AppointmentBookingService());
            var customer = (new Customer());

            // Act
            await customerController.Create(customer);

            // Assert
            Assert.NotEmpty(context.Customers);
        }

        [Fact]
        public async Task ServiceProvider_ShouldCreateNewServiceProviderAsync()
        {
            // Assemble
            var context = new ApplicationContext(DbAssembly().Options);
            var serviceProviderController = new ServiceProviderController(context, new AppointmentBookingService());
            var serviceProvider = (new ServiceProvider ());

            // Act
            await serviceProviderController.Create(serviceProvider);

            // Assert
            Assert.NotEmpty(context.ServiceProviders);
        }

        [Fact]
        public async Task Appointment_ShouldCreateNewAppointmentAsync()
        {
            // Assemble
            var context = new ApplicationContext(DbAssembly().Options);
            var appointmentController = new AppointmentController(context, new AppointmentBookingService());
            var appointment = new Appointment()
            {
                Customer = new Customer(),
                ServiceProvider = new ServiceProvider(),
                Day = 0,
                Time = 0
            };

            // Act
            await appointmentController.Create(appointment);

            // Assert
            Assert.NotEmpty(context.Appointments);
        }

        [Fact]
        public void AppointmentBookingService_ShouldNotBookInvalidAppointment()
        {
            // Assemble
            var context = new ApplicationContext(DbAssembly().Options);
            var customer1 = new Customer();
            var customer2 = new Customer();
            var serviceProvider1 = new ServiceProvider();
            var serviceProvider2 = new ServiceProvider();
            context.Add(customer1);
            context.Add(customer2);
            context.Add(serviceProvider1);
            context.Add(serviceProvider2);
            context.SaveChanges();
            var appointment1 = new Appointment()
            {
                CustomerId = customer1.CustomerId,
                ServiceProviderId = serviceProvider1.ServiceProviderId,
                Day = 0,
                Time = 0
            };
            var appointment2 = new Appointment()
            {
                CustomerId = customer1.CustomerId,
                ServiceProviderId = serviceProvider2.ServiceProviderId,
                Day = 0,
                Time = 0
            };

            // Act
            context.Add(appointment1);
            context.SaveChanges();

            bool isValid = false;

            // Assert
            Assert.Throws<InvalidAppointmentException>(() =>
            {
                isValid = new AppointmentBookingService().BookAppointment(appointment2, context);
            });
        }

        public DbContextOptionsBuilder<ApplicationContext> DbAssembly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
#pragma warning disable CS0618 // Type or member is obsolete
            optionsBuilder.UseInMemoryDatabase();
#pragma warning restore CS0618 // Type or member is obsolete
            return optionsBuilder;
        }
    }
}