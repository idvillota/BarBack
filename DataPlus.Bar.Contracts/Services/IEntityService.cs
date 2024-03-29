﻿using System;
using System.Collections.Generic;

namespace DataPlus.Bar.Contracts.Services
{
    public interface IEntityService<T>
    {
        IList<T> GetAll();
        T GetById(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
