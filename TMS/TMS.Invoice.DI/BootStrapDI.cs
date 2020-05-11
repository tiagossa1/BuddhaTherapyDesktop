using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Invoice.Domain.Interfaces;
using TMS.Invoice.Domain.Services;
using TMS.Invoice.Repository.Repository;
using TMS.Invoice.Service.Interfaces;
using TMS.Invoice.Service.Service;

namespace TMS.Invoice.DI
{
    public static class BootStrapDI
    {
        public static Container Bootstrap()
        {
            // Create the container as usual.
            Container container = new Container();

            // Register your types, for instance:
            container.Register<IInvoiceDomainService, InvoiceDomainService>();
            container.Register<IInvoiceRepository, InvoiceRepository>();
            container.Register<IInvoiceService, InvoiceService>();
            // Optionally verify the container.
            container.Verify();
            return container;
        }
    }
}
