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
    public class IngredientService: BaseService, IIngredientService
    {
        public IngredientService(IWrapperRepository wrapperRepository, ILoggerManager logger)
            :base(wrapperRepository, logger)
        {
        }      

        public IList<Ingredient> GetAll()
        {
            try
            {
                return _wrapperRepository.Ingredient.GetAll().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("IngredientService::GetAll::" + ex.Message);
                throw;
            }
        }

        public Ingredient GetById(Guid ingredientId)
        {
            try
            {
                return _wrapperRepository.Ingredient.GetById(ingredientId);

            }
            catch (Exception ex)
            {
                _logger.LogError("IngredientService::GetById::" + ex.Message);
                throw;
            }
        }

        public void Create(Ingredient ingredient)
        {
            try
            {
                _wrapperRepository.Ingredient.Create(ingredient);
                _wrapperRepository.Ingredient.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("IngredientService::Create::" + ex.Message);
                throw;
            }
        }

        public void Update(Ingredient ingredient)
        {
            try
            {
                _wrapperRepository.Ingredient.Update(ingredient);
                _wrapperRepository.Ingredient.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("IngredientService::Update::" + ex.Message);
                throw;
            }
        }

        public void Delete(Ingredient ingredient)
        {
            try
            {
                _wrapperRepository.Ingredient.Delete(ingredient);
                _wrapperRepository.Ingredient.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("IngredientService::Delete::" + ex.Message);
                throw;
            }
        }
    }
}

