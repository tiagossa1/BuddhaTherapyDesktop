using SimpleInjector;
using TMS.Appointment.Domain.Interfaces;
using TMS.Appointment.Domain.Services;
using TMS.Appointment.Repository;
using TMS.Appointment.Service.Interfaces;
using TMS.Appointment.Service.Service;

namespace TMS.Appointment.DI
{
    public static class BootStrapDI
    {
        public static Container Bootstrap()
        {
            // Create the container as usual.
            Container container = new Container();

            // Register your types, for instance:
            container.Register<IAppointmentDomainService, AppointmentDomainService>();
            container.Register<IAppointmentRepository, AppointmentRepository>();
            container.Register<IAppointmentService, AppointmentService>();
            // Optionally verify the container.
            container.Verify();
            return container;
        }
    }
}
