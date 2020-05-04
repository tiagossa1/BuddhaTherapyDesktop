using SimpleInjector;
using TMS.Client.Domain.Interfaces;
using TMS.Client.Domain.Services;
using TMS.Clientes.Repository.Repository;
using TMS.Clientes.Services.Interfaces;

namespace TMS.Client.DI
{
    public static class BootStrapDI
    {
        public static Container Bootstrap()
        {
            // Create the container as usual.
            Container container = new Container();

            // Register your types, for instance:
            container.Register<IClientDomainService, ClientDomainService>();
            container.Register<IClientRepository, ClientRepository>();
            container.Register<IClientService, ClientService>();
            // Optionally verify the container.
            container.Verify();
            return container;
        }
    }
}
