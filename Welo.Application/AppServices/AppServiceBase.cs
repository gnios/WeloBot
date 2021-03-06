﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Welo.Application.Interfaces;
using Welo.Domain.Entities.Base;
using Welo.Domain.Interfaces.Services;

namespace Welo.Application
{
    [Serializable]
    public class AppServiceBase<TEntity, TIdentifier> : IAppServiceBase<TEntity, TIdentifier> where TEntity : IEntity<TIdentifier>, new() where TIdentifier : struct
    {
        public readonly IService<TEntity, TIdentifier> _service;

        public AppServiceBase(IService<TEntity, TIdentifier> service)
        {
            _service = service;
        }

        public bool Exists(TIdentifier id) => _service.Exists(id);

        public TEntity Add(TEntity entity) => _service.Add(entity);

        public TEntity Update(TEntity entity) => _service.Update(entity);

        public void Remove(TEntity entity) => _service.Remove(entity);

        public void Remove(TIdentifier id) => _service.Remove(id);

        public TEntity Get(TIdentifier id) => _service.Get(id);

        public IEnumerable<TEntity> GetAll() => _service.GetAll();

        public long Count() => _service.Count();

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> query) => _service.Find(query);
    }
}