using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDbModel.Model;
using MongoDbModel.Repository;
using System.Configuration;
using System.Data.Common;

namespace MongoDbModel.UnitOfWork
{
   public class StudentUnitOfwork
    {
        private IMongoDatabase _database;
        protected StudentRepository<Student> _students;
        protected MongoServer _server;

        public StudentUnitOfwork()
        {
            var connectionString = "mongodb://127.0.0.1:27017";
            var client = new MongoClient(connectionString);           
            var databaseName = "students";            
            _database = client.GetDatabase(databaseName);
        }

        public StudentRepository<Student> Student
        {
            get
            {
                if (_students == null) _students = new StudentRepository<Student>(_database, "student");
                return _students;
            }
        }
    }
}
