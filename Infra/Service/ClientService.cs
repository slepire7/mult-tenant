using Core.Interfaces.Data;
using Model = Core.Model.Apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Service
{
    public class ClientService : Core.Interfaces.Services.IClientService
    {
        private readonly IRepository<Model.Crm.Clientes, Data.AllDbTenantsContext> _clientRepository;
        public ClientService(IRepository<Model.Crm.Clientes, Data.AllDbTenantsContext> ClientRepository)
        {
            _clientRepository = ClientRepository;
        }
        public Model.Crm.Clientes Get()
        {
            return _clientRepository.GetAll().FirstOrDefault();
        }
    }
}
