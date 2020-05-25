//using System;
//using MongoDB.Bson;
//using MongoDB.Driver;
//using MongoDB.Driver.GridFS;

//namespace MongoDBConsole
//{
//    class Program
//    {
//        string connectionString = "mongodb://localhost";
//        static void Main(string[] args)
//        {
//            string connectionString = "mongodb://localhost";
//            Console.WriteLine("Creating Clent..................");
//            MongoClient client = null;
//            try
//            {
//                client = new MongoClient(connectionString);
//                Console.WriteLine("client created sucessfully.............");
//                Console.WriteLine($"Client{client.ToString()}");
//            }
//            catch(Exception ex )
//            {
//                Console.WriteLine("Failed to create client");
//                Console.WriteLine(ex.Message);
//            }

//            Console.WriteLine("Initiating MongoDB server.............");
//            IMongoDatabase dataBase = client.GetDatabase("Employee");
//            //Console.WriteLine($"Database Name{dataBase.ListCollections.}");
//        }
//    }
//}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ConsAppMongoDBCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017");

                //Database List  
                var dbList = dbClient.ListDatabases().ToList();

                Console.WriteLine("The list of databases are :");
                foreach (var item in dbList)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\n\n");

                //Get Database and Collection  
                IMongoDatabase db = dbClient.GetDatabase("employee");
                var collList = db.ListCollections().ToList();
                Console.WriteLine("The list of collections are :");
                foreach (var item in collList)
                {
                    Console.WriteLine(item);
                }

                var things = db.GetCollection<BsonDocument>("EmployeeDetails");

                //CREATE  
                BsonElement personFirstNameElement = new BsonElement("EmployeeId", "2");

                BsonDocument personDoc = new BsonDocument();
                personDoc.Add(personFirstNameElement);
                personDoc.Add(new BsonElement("Name", "Shyam"));

                things.InsertOne(personDoc);

                //UPDATE  
                //BsonElement updatePersonFirstNameElement = new BsonElement("PersonFirstName", "Souvik");

                //BsonDocument updatePersonDoc = new BsonDocument();
                //updatePersonDoc.Add(updatePersonFirstNameElement);
                //updatePersonDoc.Add(new BsonElement("PersonAge", 24));

                //BsonDocument findPersonDoc = new BsonDocument(new BsonElement("PersonFirstName", "Sankhojjal"));

                //var updateDoc = things.FindOneAndReplace(findPersonDoc, updatePersonDoc);

                //Console.WriteLine(updateDoc);

                ////DELETE  
                //BsonDocument findAnotherPersonDoc = new BsonDocument(new BsonElement("PersonFirstName", "Sourav"));

                //things.FindOneAndDelete(findAnotherPersonDoc);

                //READ  
                var resultDoc = things.Find(new BsonDocument()).ToList();
                foreach (var item in resultDoc)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
