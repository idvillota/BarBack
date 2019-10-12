using DataPlus.Bar.Contracts.Logger;
using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Contracts.Services;
using DataPlus.Bar.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataPlus.Bar.Services
{
    public class PaymentService: BaseService, IPaymentService
    {
        public PaymentService(IWrapperRepository wrapperRepository, ILoggerManager logger)
            :base(wrapperRepository, logger)
        {
        }      

        public IList<Payment> GetAll()
        {
            try
            {
                return _wrapperRepository.Payment.GetAll().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("PaymentService::GetAll::" + ex.Message);
                throw;
            }
        }

        public Payment GetById(Guid paymentId)
        {
            try
            {
                return _wrapperRepository.Payment.GetById(paymentId);

            }
            catch (Exception ex)
            {
                _logger.LogError("PaymentService::GetById::" + ex.Message);
                throw;
            }
        }

        public void Create(Payment payment)
        {
            try
            {
                _wrapperRepository.Payment.Create(payment);
                _wrapperRepository.Payment.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("PaymentService::Create::" + ex.Message);
                throw;
            }
        }

        public void Update(Payment payment)
        {
            try
            {
                _wrapperRepository.Payment.Update(payment);
                _wrapperRepository.Payment.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("PaymentService::Update::" + ex.Message);
                throw;
            }
        }

        public void Delete(Payment payment)
        {
            try
            {
                _wrapperRepository.Payment.Delete(payment);
                _wrapperRepository.Payment.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("PaymentService::Delete::" + ex.Message);
                throw;
            }
        }
    }
}

