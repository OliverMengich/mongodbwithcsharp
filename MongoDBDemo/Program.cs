using System;

namespace MongoDBDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Install the MongoDB. Driver Dependency
            Console.WriteLine("Hello World :-) We are working today with databases");
            // 2 Initialize the database
            MongoDB db = new MongoDB("AddressBook");
            // ==================================================================================================
            // INSERTS RECORD TO A DATABASE
            /*PersonModel person = new PersonModel
            {
                FirstName = "Susan",
                LastName = "Kapkoyo",
                PrimaryAddress = new AddressModel
                {
                    City= "Kabarnet",
                    State="Baringo",
                    StreetAddress = "21-30400",
                    ZipCode = "+254"
                }
            };

            //3 Inserting a record to the database
            // converts it into Bson. and its stored to the database
            db.InsertRecord("Users", person);
            Console.WriteLine("Data inserted to the database");*/

            //=================================================================================================
            // WE READ FROM THE DATABASE
            /*var records = db.LoadRecords<PersonModel>("Users");
            foreach(var item in records)
            {
                Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName}");

                if(item.PrimaryAddress != null)
                {
                    Console.Write($" From city {item.PrimaryAddress.City}");
                }
            }*/

            //=================================================================================================
            // WE READ FROM THE DATABASE WITH SPECIFIC ID
            //var oneRec = db.LoadRecordById<PersonModel>("Users", new Guid("3acf066a-4ee4-4fda-a0ee-7bf31c47a94b"));
            //Console.WriteLine(oneRec);

            //===============================================================================================
            // WE UPDATE A RECORD FROM THE DATABASE GIVEN SPECIFIC ID WITH A NEW RECORD
            //var oneRec = db.LoadRecordById<PersonModel>("Users", new Guid("3acf066a-4ee4-4fda-a0ee-7bf31c47a94b"));
            //oneRec.DateOfBirth = new DateTime(2000, 2, 14, 0, 0, 0, DateTimeKind.Utc);
            //db.UpsertRecord("Users", oneRec.Id, oneRec);

            //===============================================================================================
            // WE DELETE A RECORD FROM THE DATABASE WITH SPECIFIC ID
            //var oneRec = db.LoadRecordById<PersonModel>("Users", new Guid("3acf066a-4ee4-4fda-a0ee-7bf31c47a94b"));
            //db.DeleteRecord<PersonModel>("Users", oneRec.Id);

            //=================================================================================================
            // WE READ FROM THE DATABASE
            var records = db.LoadRecords<NameModel>("Users");
            foreach(var item in records)
            {
                Console.WriteLine($" {item.Id} {item.FirstName} {item.LastName}");
            }
            Console.ReadLine();
        }
    }
}
