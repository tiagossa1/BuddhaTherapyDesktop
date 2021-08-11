using System;
using System.Collections.Generic;
using TMS.Client.Domain.Model;

namespace TMS.Client.Domain.Interfaces
{
    public interface IClientRepository
    {
        bool Create(Model.ClientModel obj);

<<<<<<< HEAD
        bool Put(Model.ClientModel obj);
        bool Exists(Model.ClientModel obj);
=======
        bool Edit(Model.ClientModel obj);
>>>>>>> d0773f26227fc8a3d8bff854b8a182039290b894

        bool Delete(Guid id);

        ClientModel Get(Guid id);

        List<ClientModel> GetAll();
        long Count();
    }
}