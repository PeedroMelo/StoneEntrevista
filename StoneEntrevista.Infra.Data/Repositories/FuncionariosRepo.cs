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
            _mongoDbContext = new MongoDbContext(mongoConnectionConfig);
            // System.Console.WriteLine(_mongoDbContext.);
            _collection = _mongoDbContext.GetCollection<Funcionario>();
            if (_collection != null)
            {
                System.Console.WriteLine("Collection reached.");
            }
        }

        public List<Funcionario> BuscarFuncionarios()
        {
            System.Console.WriteLine("Preparing connection to cluster");
            var client = new MongoClient("mongodb+srv://aircnc:aircnc2019@vieirapcmc0.cu8jq.mongodb.net/");
            if (client != null) {
                System.Console.WriteLine("Connected.");
            }

            var dbList = client.ListDatabases().ToList();

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }

            System.Console.WriteLine("Preparing connection to database");
            var database = client.GetDatabase("StonePL");
            if (database != null) {
                System.Console.WriteLine("Connected.");
            }

            System.Console.WriteLine("Preparing connection to collection");
            var collection = database.GetCollection<Funcionario>("Funcionario");
            if (collection != null) {
                System.Console.WriteLine("Connected.");
            }

            return collection.Find(x => x.Matricula == "0009968").ToList();
        }
    }
}