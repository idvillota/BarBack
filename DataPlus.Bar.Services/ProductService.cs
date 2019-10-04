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
    public class ProductService: BaseService, IProductService
    {
        public ProductService(IWrapperRepository wrapperRepository, ILoggerManager logger)
            :base(wrapperRepository, logger)
        {
        }      

        public IList<Product> GetAll()
        {
            try
            {
                return _wrapperRepository.Product.GetAll().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductService::GetAll::" + ex.Message);
                throw;
            }
        }

        public Product GetById(Guid productId)
        {
            try
            {
                return _wrapperRepository.Product.GetById(productId);

            }
            catch (Exception ex)
            {
                _logger.LogError("ProductService::GetById::" + ex.Message);
                throw;
            }
        }

        public void Create(Product product)
        {
            try
            {
                _wrapperRepository.Product.Create(product);
                _wrapperRepository.Product.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductService::Create::" + ex.Message);
                throw;
            }
        }

        public void Update(Product product)
        {
            try
            {
                _wrapperRepository.Product.Update(product);
                _wrapperRepository.Product.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductService::Update::" + ex.Message);
                throw;
            }
        }

        public void Delete(Product product)
        {
            try
            {
                _wrapperRepository.Product.Delete(product);
                _wrapperRepository.Product.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductService::Delete::" + ex.Message);
                throw;
            }
        }
    }
}

