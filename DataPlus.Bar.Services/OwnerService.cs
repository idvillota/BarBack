using DataPlus.Bar.Contracts.Logger;
using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Contracts.Services;
using DataPlus.Bar.Entities.ExtendedModels;
using DataPlus.Bar.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataPlus.Bar.Services
{
    public class OwnerService: BaseService, IOwnerService
    {
        public OwnerService(IWrapperRepository wrapperRepository, ILoggerManager logger)
            :base(wrapperRepository, logger)
        {
        }

        public IList<OwnerExtended> GetAllWithAccounts()
        {
            try
            {
                //return _wrapperRepository.Owner.GetAllWithAccounts().ToList();

                var owners = _wrapperRepository.Owner.GetAll().ToList();
                var ownerExtendeds = new List<OwnerExtended>();

                foreach (var owner in owners)
                {
                    ownerExtendeds.Add(new OwnerExtended(owner)
                    {
                        Accounts = _wrapperRepository.Account.GetByCondition(x => x.OwnerId == owner.Id)
                    });
                }

                return ownerExtendeds;

            }
            catch (Exception ex)
            {
                _logger.LogError($"OwnerService::GetAllWithAccounts::{ex.Message}");
                throw;
            }
        }

        public IList<Owner> GetAll()
        {
            try
            {
                return _wrapperRepository.Owner.GetAll().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("OwnerService::GetAll::" + ex.Message);
                throw;
            }
        }

        public Owner GetById(Guid ownerId)
        {
            try
            {
                return _wrapperRepository.Owner.GetById(ownerId);

            }
            catch (Exception ex)
            {
                _logger.LogError("OwnerService::GetById::" + ex.Message);
                throw;
            }
        }

        public OwnerExtended GetByIdWithDetails(Guid ownerId)
        {
            try
            {
                return new OwnerExtended(GetById(ownerId)){
                    Accounts = _wrapperRepository.Account.GetByCondition(x => x.OwnerId == ownerId)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("OwnerService::GetByIdWithDetails::" + ex.Message);
                throw;
            }
        }
        
        public void Create(Owner owner)
        {
            try
            {
                _wrapperRepository.Owner.Create(owner);
                _wrapperRepository.Owner.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("OwnerService::Create::" + ex.Message);
                throw;
            }
        }

        public void Update(Owner owner)
        {
            try
            {
                _wrapperRepository.Owner.Update(owner);
                _wrapperRepository.Owner.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("OwnerService::Update::" + ex.Message);
                throw;
            }
        }

        public void Delete(Owner owner)
        {
            try
            {
                _wrapperRepository.Owner.Delete(owner);
                _wrapperRepository.Owner.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("OwnerService::Delete::" + ex.Message);
                throw;
            }
        }
    }
}

