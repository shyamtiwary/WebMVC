using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDbModel;
using MongoDbModel.Model;
using MongoDbModel.UnitOfWork;

namespace MongoDbWebAPICRUD.Business
{
    public class StudentService : IStudentService
    {
        private readonly StudentUnitOfwork _sUnitOfWork;

        public StudentService() => _sUnitOfWork = new StudentUnitOfwork();

        public void Delete(string id) => _sUnitOfWork.Student.Delete(id);
        public List<Student> All => _sUnitOfWork.Student.GetAll();

        public void Insert(Student student) => _sUnitOfWork.Student.Insert(student);

        public void Insert(List<Student> student) => _sUnitOfWork.Student.Insert(student);

        public void Update(Student student) => _sUnitOfWork.Student.Update(student);

        Student IStudentService.Get(string i) => _sUnitOfWork.Student.Get(i);
    }
}
