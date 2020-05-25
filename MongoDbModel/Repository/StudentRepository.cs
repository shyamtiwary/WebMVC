using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDbModel.Model;

namespace MongoDbModel.Repository
{
    public class StudentRepository<T> where T : class
    {
        private IMongoDatabase _dataBase;
        private string _tbleName;
        private IMongoCollection<Student> _collection;

        public StudentRepository(IMongoDatabase db, string tblName)
        {
            _dataBase = db;
            _tbleName = tblName;
            _collection = _dataBase.GetCollection<Student>(_tbleName);
        }

        public Student Get(string id) =>
           _collection.Find<Student>(student => student.Id == id).FirstOrDefault();

        public List<Student> GetAll() =>
          _collection.Find(book => true).ToList();

        public void Delete(string id) =>
           _collection.DeleteOne(student => student.Id == id);

        public void Update(Student studentIn) =>
          _collection.ReplaceOne(student => student.Id == studentIn.Id, studentIn);

        public void Insert(Student entity)
        {
            _collection.InsertOne(entity);
        }

        public void Insert(List<Student> entity)
        {
            _collection.InsertMany(entity);
        }
    }
}
