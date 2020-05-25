using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDbModel;
using MongoDbModel.Model;

namespace MongoDbWebAPICRUD.Business
{
    public interface IStudentService
    {
        void Insert(Student student);

        void Insert(List<Student> student);
        Student Get(string i);
        List<Student> All { get; }

        void Delete(string id);
        void Update(Student student);
    }
}
