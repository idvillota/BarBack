using DataPlus.Bar.Contracts.Logger;
using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Contracts.Services;
using DataPlus.Bar.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataPlus.Bar.Services
{
    public class TableService: BaseService, ITableService
    {
        public TableService(IWrapperRepository wrapperRepository, ILoggerManager logger)
            :base(wrapperRepository, logger)
        {
        }      

        public IList<Table> GetAll()
        {
            try
            {
                return _wrapperRepository.Table.GetAll().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("TableService::GetAll::" + ex.Message);
                throw;
            }
        }

        public Table GetById(Guid tableId)
        {
            try
            {
                return _wrapperRepository.Table.GetById(tableId);

            }
            catch (Exception ex)
            {
                _logger.LogError("TableService::GetById::" + ex.Message);
                throw;
            }
        }

        public void Create(Table table)
        {
            try
            {
                _wrapperRepository.Table.Create(table);
                _wrapperRepository.Table.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("TableService::Create::" + ex.Message);
                throw;
            }
        }

        public void Update(Table table)
        {
            try
            {
                _wrapperRepository.Table.Update(table);
                _wrapperRepository.Table.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("TableService::Update::" + ex.Message);
                throw;
            }
        }

        public void Delete(Table table)
        {
            try
            {
                _wrapperRepository.Table.Delete(table);
                _wrapperRepository.Table.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("TableService::Delete::" + ex.Message);
                throw;
            }
        }
    }
}

