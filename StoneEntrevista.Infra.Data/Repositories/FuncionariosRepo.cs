using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using StoneEntrevista.Application.Entities;
using StoneEntrevista.Application.Interfaces;
using StoneEntrevista.Infra.Data.Config;
using StoneEntrevista.Infra.Data.Context;

namespace StoneEntrevista.Infra.Data.Repositories
{
    public class FuncionariosRepo : IFuncionariosRepo
    {
        private readonly IMongoDbContext _mongoDbContext;
        private readonly IMongoCollection<Funcionario> _collection;

        public FuncionariosRepo(IOptions<MongoConnectionConfig> mongoConnectionConfig)
        {
            try
            {
                _mongoDbContext = new MongoDbContext(mongoConnectionConfig);
                _collection = _mongoDbContext.GetCollection<Funcionario>();
                if (_collection != null)
                {
                    System.Console.WriteLine("Collection reached.");
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Fail to connect to database: {e.Message}");
            }
        }

        public void Add(Funcionario funcionario)
        {
            try
            {
                _collection.InsertOne(funcionario);
            }
            catch (Exception e)
            {
                throw new Exception($"Fail to insert a new documento to database: {e.Message}");
            }
        }

        public List<Funcionario> GetAll()
        {
            return _collection.Find(funcionario => true).ToList();
        }

        public Funcionario GetById(string matricula)
        {
            return _collection.Find<Funcionario>(funcionario => funcionario.Matricula == matricula).FirstOrDefault();
        }
    }
}