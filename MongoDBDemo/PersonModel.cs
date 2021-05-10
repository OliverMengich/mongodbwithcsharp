using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDBDemo
{
    public class PersonModel
    {
        // The person model class defines the schema of the database
        [BsonId] // _id of the Property.
        // if quid is null its an insert. otherwise it is an updata
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel PrimaryAddress { get; set; }
        [BsonElement("DOB")]
        public DateTime DateOfBirth { get; set; }
    }
}
