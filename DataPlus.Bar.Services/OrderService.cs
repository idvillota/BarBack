using DataPlus.Bar.Contracts.Logger;
using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Contracts.Services;
using DataPlus.Bar.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataPlus.Bar.Services
{
    public class OrderService: BaseService, IOrderService
    {
        public OrderService(IWrapperRepository wrapperRepository, ILoggerManager logger)
            :base(wrapperRepository, logger)
        {
        }      

        public IList<Order> GetAll()
        {
            try
            {
                return _wrapperRepository.Order.GetAll().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderService::GetAll::" + ex.Message);
                throw;
            }
        }

        public Order GetById(Guid orderId)
        {
            try
            {
                return _wrapperRepository.Order.GetById(orderId);

            }
            catch (Exception ex)
            {
                _logger.LogError("OrderService::GetById::" + ex.Message);
                throw;
            }
        }

        public void Create(Order order)
        {
            try
            {
                _wrapperRepository.Order.Create(order);
                _wrapperRepository.Order.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderService::Create::" + ex.Message);
                throw;
            }
        }

        public void Update(Order order)
        {
            try
            {
                _wrapperRepository.Order.Update(order);
                _wrapperRepository.Order.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderService::Update::" + ex.Message);
                throw;
            }
        }

        public void Delete(Order order)
        {
            try
            {
                _wrapperRepository.Order.Delete(order);
                _wrapperRepository.Order.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderService::Delete::" + ex.Message);
                throw;
            }
        }
    }
}

