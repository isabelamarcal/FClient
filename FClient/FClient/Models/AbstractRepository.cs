using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace FClient.Models
{
    public abstract class AbstractRepository<TEntity, TKey>
    where TEntity : class
    {
        protected string StringConnection { get; } = "Server = localhost; Database=fclient;Uid=root;Pwd=root;persistsecurityinfo=True;SslMode=none";

        public abstract List<TEntity> GetAll();
        public abstract TEntity GetById(TKey id);
        public abstract void Save(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract void Delete(TEntity entity);
    }
}