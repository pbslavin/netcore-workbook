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
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
#pragma warning disable CS0618 // Type or member is obsolete
            optionsBuilder.UseInMemoryDatabase();
#pragma warning restore CS0618 // Type or member is obsolete
            var context = new ApplicationContext(optionsBuilder.Options);
            var appointmentBookingService = new AppointmentBookingService();
            var customerController = new CustomerController(context, appointmentBookingService);
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
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
#pragma warning disable CS0618 // Type or member is obsolete
            optionsBuilder.UseInMemoryDatabase();
#pragma warning restore CS0618 // Type or member is obsolete
            var context = new ApplicationContext(optionsBuilder.Options);
            var appointmentBookingService = new AppointmentBookingService();
            var serviceProviderController = new ServiceProviderController(context, appointmentBookingService);
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
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
#pragma warning disable CS0618 // Type or member is obsolete
            optionsBuilder.UseInMemoryDatabase();
#pragma warning restore CS0618 // Type or member is obsolete
            var context = new ApplicationContext(optionsBuilder.Options);
            var appointmentBookingService = new AppointmentBookingService();
            var appointmentController = new AppointmentController(context, appointmentBookingService);
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

        //        [Fact]
        //        public void AppointmentBookingService_ShouldNotBookInvalidAppointment()
        //        {
        //            // Assemble
        //            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        //#pragma warning disable CS0618 // Type or member is obsolete
        //            optionsBuilder.UseInMemoryDatabase();
        //#pragma warning restore CS0618 // Type or member is obsolete
        //            var context = new ApplicationContext(optionsBuilder.Options);
        //            var appointmentBookingService = new AppointmentBookingService();
        //            var customer1 = new Customer();
        //            var customer2 = new Customer();
        //            var serviceProvider1 = new ServiceProvider();
        //            var serviceProvider2 = new ServiceProvider();
        //            var appointment1 = new Appointment()
        //            {
        //                Customer = customer1,
        //                ServiceProvider = serviceProvider1,
        //                Day = 0,
        //                Time = 0
        //            };
        //            var appointment2 = new Appointment()
        //            {
        //                Customer = customer1,
        //                ServiceProvider = serviceProvider2,
        //                Day = 0,
        //                Time = 0
        //            };

        //            // Act
        //            appointmentBookingService.BookAppointment(appointment1, context);
        //            context.Add(appointment1);
        //            bool isValid = appointmentBookingService.BookAppointment(appointment2, context);

        //            // Assert
        //            Assert.Equal("false", isValid.ToString());
        //        }
    }
}