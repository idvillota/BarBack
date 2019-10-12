using DataPlus.Bar.Contracts.Logger;
using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Contracts.Services;
using DataPlus.Bar.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataPlus.Bar.Services
{
    public class ClientService: BaseService, IClientService
    {
        public ClientService(IWrapperRepository wrapperRepository, ILoggerManager logger)
            :base(wrapperRepository, logger)
        {
        }      

        public IList<Client> GetAll()
        {
            try
            {
                return _wrapperRepository.Client.GetAll().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("ClientService::GetAll::" + ex.Message);
                throw;
            }
        }

        public Client GetById(Guid clientId)
        {
            try
            {
                return _wrapperRepository.Client.GetById(clientId);

            }
            catch (Exception ex)
            {
                _logger.LogError("ClientService::GetById::" + ex.Message);
                throw;
            }
        }

        public void Create(Client client)
        {
            try
            {
                _wrapperRepository.Client.Create(client);
                _wrapperRepository.Client.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("ClientService::Create::" + ex.Message);
                throw;
            }
        }

        public void Update(Client client)
        {
            try
            {
                _wrapperRepository.Client.Update(client);
                _wrapperRepository.Client.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("ClientService::Update::" + ex.Message);
                throw;
            }
        }

        public void Delete(Client client)
        {
            try
            {
                _wrapperRepository.Client.Delete(client);
                _wrapperRepository.Client.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("ClientService::Delete::" + ex.Message);
                throw;
            }
        }
    }
}

