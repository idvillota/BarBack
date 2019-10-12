using DataPlus.Bar.Contracts.Logger;
using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Contracts.Services;
using DataPlus.Bar.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataPlus.Bar.Services
{
    public class OrderItemService: BaseService, IOrderItemService
    {
        public OrderItemService(IWrapperRepository wrapperRepository, ILoggerManager logger)
            :base(wrapperRepository, logger)
        {
        }      

        public IList<OrderItem> GetAll()
        {
            try
            {
                return _wrapperRepository.OrderItem.GetAll().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderItemService::GetAll::" + ex.Message);
                throw;
            }
        }

        public OrderItem GetById(Guid orderItemId)
        {
            try
            {
                return _wrapperRepository.OrderItem.GetById(orderItemId);

            }
            catch (Exception ex)
            {
                _logger.LogError("OrderItemService::GetById::" + ex.Message);
                throw;
            }
        }

        public void Create(OrderItem orderItem)
        {
            try
            {
                _wrapperRepository.OrderItem.Create(orderItem);
                _wrapperRepository.OrderItem.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderItemService::Create::" + ex.Message);
                throw;
            }
        }

        public void Update(OrderItem orderItem)
        {
            try
            {
                _wrapperRepository.OrderItem.Update(orderItem);
                _wrapperRepository.OrderItem.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderItemService::Update::" + ex.Message);
                throw;
            }
        }

        public void Delete(OrderItem orderItem)
        {
            try
            {
                _wrapperRepository.OrderItem.Delete(orderItem);
                _wrapperRepository.OrderItem.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderItemService::Delete::" + ex.Message);
                throw;
            }
        }
    }
}

