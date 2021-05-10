using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MongoDBDemo
{
    public class MongoDB
    {
        private IMongoDatabase db;

        public MongoDB(string database)
        {
            // this connects to a server runs locally on your PC
            var client = new MongoClient(); // initializes the database property
            db = client.GetDatabase(database);// connects to the database
        }
        public void InsertRecord<T>(string table, T record)
        {
            // gets the collection.
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record); // inserts one record to the Database
        }
        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }
        public T LoadRecordById<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            return collection.Find(filter).First();
        }
        //inserts or updates on the table
        public void UpsertRecord<T>(string table,Guid id, T record)
        {
            var collection = db.GetCollection<T>(table);
            var result = collection.ReplaceOne( 
                new BsonDocument("_id",id), //finds the document specified by the given ID
                record, //deletes the record and replaces the record with the given ID
                new UpdateOptions {IsUpsert=true }); 
        }
        public void DeleteRecord<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }
    }
}
