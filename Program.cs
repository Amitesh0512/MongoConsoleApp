using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // Connection string to MongoDB
        var connectionString = "mongodb+srv://amitesh0512:AnupamAlok%402099@cluster0.s5hw12l.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("testdb");
        InsertPerson(client);    
        InsertPersonWithAddress(client);
        UpdatePerson(client);
        //DeletePerson(client);
        UpdatePersonWithAddress(client);
        //DeletePersonWithAddress(client);
        InsertPersonWithAddressAndUpdate(client);
        //DeletePersonWithAddressAndUpdate(client);
        InsertPersonWithAddressAndDelete(client);
        UpdatePersonWithAddressAndDelete(client);
        InsertPersonWithAddressAndUpdateAndDelete(client);
        Console.WriteLine("Operations completed successfully.");
        Console.ReadLine();    
    }

    public static void InsertPerson(MongoClient client)
    {
        var database = client.GetDatabase("testdb");
        var collection = database.GetCollection<Person>("people");
        
        // Insert a new person
        var person = new Person { Name = "John Daffali", Age = 32 };
        collection.InsertOne(person);

        // Retrieve all people
        var people = collection.Find(new BsonDocument()).ToList();
        foreach (var p in people)
        {
            Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
        }
    }

    public static void InsertPersonWithAddress(MongoClient client)
    {
        var database = client.GetDatabase("testdb");
        var collection = database.GetCollection<PersonWithAddress>("peopleWithAddress");

        // Insert a new person with address
        var personWithAddress = new PersonWithAddress
        {
            Name = "John Daffali",
            Age = 32,
            Address = new Address
            {
                Street = "123 Main St",
                City = "New York",
                State = "NY",
                ZipCode = "10001"
            }
        };
        collection.InsertOne(personWithAddress);

        // Retrieve all people with address
        var peopleWithAddress = collection.Find(new BsonDocument()).ToList();
        foreach (var p in peopleWithAddress)
        {
            Console.WriteLine($"Name: {p.Name}, Age: {p.Age}, Address: {p.Address.Street}, {p.Address.City}, {p.Address.State}, {p.Address.ZipCode}");
        }
    }
    public static void UpdatePerson(MongoClient client)
    {
        var database = client.GetDatabase("testdb");
        var collection = database.GetCollection<Person>("people");

        // Update a person's age
        var filter = Builders<Person>.Filter.Eq(p => p.Name, "John Daffali");
        var update = Builders<Person>.Update.Set(p => p.Age, 33);
        collection.UpdateOne(filter, update);

        // Retrieve the updated person
        var updatedPerson = collection.Find(filter).FirstOrDefault();
        Console.WriteLine($"Updated Age: {updatedPerson.Age}");
    }
    public static void DeletePerson(MongoClient client)
    {
        var database = client.GetDatabase("testdb");
        var collection = database.GetCollection<Person>("people");

        // Delete a person
        var filter = Builders<Person>.Filter.Eq(p => p.Name, "John Daffali");
        collection.DeleteOne(filter);

        // Verify deletion
        var deletedPerson = collection.Find(filter).FirstOrDefault();
        Console.WriteLine(deletedPerson == null ? "Person deleted successfully." : "Failed to delete person.");
    }
    public static void UpdatePersonWithAddress(MongoClient client)
    {
        var database = client.GetDatabase("testdb");
        var collection = database.GetCollection<PersonWithAddress>("peopleWithAddress");

        // Update a person's address
        var filter = Builders<PersonWithAddress>.Filter.Eq(p => p.Name, "John Daffali");
        var update = Builders<PersonWithAddress>.Update.Set(p => p.Address.City, "Los Angeles");
        collection.UpdateOne(filter, update);

        // Retrieve the updated person with address
        var updatedPersonWithAddress = collection.Find(filter).FirstOrDefault();
        Console.WriteLine($"Updated Address: {updatedPersonWithAddress.Address.City}");
    }
    public static void DeletePersonWithAddress(MongoClient client)
    {
        var database = client.GetDatabase("testdb");
        var collection = database.GetCollection<PersonWithAddress>("peopleWithAddress");

        // Delete a person with address
        var filter = Builders<PersonWithAddress>.Filter.Eq(p => p.Name, "John Daffali");
        collection.DeleteOne(filter);

        // Verify deletion
        var deletedPersonWithAddress = collection.Find(filter).FirstOrDefault();
        Console.WriteLine(deletedPersonWithAddress == null ? "Person with address deleted successfully." : "Failed to delete person with address.");
    }
    public static void InsertPersonWithAddressAndUpdate(MongoClient client)
    {
        var database = client.GetDatabase("testdb");
        var collection = database.GetCollection<PersonWithAddress>("peopleWithAddress");

        // Insert a new person with address
        var personWithAddress = new PersonWithAddress
        {
            Name = "John Daffali",
            Age = 32,
            Address = new Address
            {
                Street = "123 Main St",
                City = "New York",
                State = "NY",
                ZipCode = "10001"
            }
        };
        collection.InsertOne(personWithAddress);

        // Update the person's address
        var filter = Builders<PersonWithAddress>.Filter.Eq(p => p.Name, "John Daffali");
        var update = Builders<PersonWithAddress>.Update.Set(p => p.Address.City, "Los Angeles");
        collection.UpdateOne(filter, update);

        // Retrieve the updated person with address
        var updatedPersonWithAddress = collection.Find(filter).FirstOrDefault();
        Console.WriteLine($"Updated Address: {updatedPersonWithAddress.Address.City}");
    }
    public static void DeletePersonWithAddressAndUpdate(MongoClient client)
    {
        var database = client.GetDatabase("testdb");
        var collection = database.GetCollection<PersonWithAddress>("peopleWithAddress");

        // Delete a person with address
        var filter = Builders<PersonWithAddress>.Filter.Eq(p => p.Name, "John Daffali");
        collection.DeleteOne(filter);

        // Verify deletion
        var deletedPersonWithAddress = collection.Find(filter).FirstOrDefault();
        Console.WriteLine(deletedPersonWithAddress == null ? "Person with address deleted successfully." : "Failed to delete person with address.");
    }
    public static void InsertPersonWithAddressAndDelete(MongoClient client)
    {
        var database = client.GetDatabase("testdb");
        var collection = database.GetCollection<PersonWithAddress>("peopleWithAddress");

        // Insert a new person with address
        var personWithAddress = new PersonWithAddress
        {
            Name = "John Daffali",
            Age = 32,
            Address = new Address
            {
                Street = "123 Main St",
                City = "New York",
                State = "NY",
                ZipCode = "10001"
            }
        };
        collection.InsertOne(personWithAddress);

        // Delete the person with address
        var filter = Builders<PersonWithAddress>.Filter.Eq(p => p.Name, "John Daffali");
        collection.DeleteOne(filter);

        // Verify deletion
        var deletedPersonWithAddress = collection.Find(filter).FirstOrDefault();
        Console.WriteLine(deletedPersonWithAddress == null ? "Person with address deleted successfully." : "Failed to delete person with address.");
    }
    public static void UpdatePersonWithAddressAndDelete(MongoClient client)
    {
        var database = client.GetDatabase("testdb");
        var collection = database.GetCollection<PersonWithAddress>("peopleWithAddress");

        // Update a person's address
        var filter = Builders<PersonWithAddress>.Filter.Eq(p => p.Name, "John Daffali");
        var update = Builders<PersonWithAddress>.Update.Set(p => p.Address.City, "Los Angeles");
        collection.UpdateOne(filter, update);

        // Delete the person with address
        collection.DeleteOne(filter);

        // Verify deletion
        var deletedPersonWithAddress = collection.Find(filter).FirstOrDefault();
        Console.WriteLine(deletedPersonWithAddress == null ? "Person with address deleted successfully." : "Failed to delete person with address.");
    }
    public static void InsertPersonWithAddressAndUpdateAndDelete(MongoClient client)
    {
        var database = client.GetDatabase("testdb");
        var collection = database.GetCollection<PersonWithAddress>("peopleWithAddress");

        // Insert a new person with address
        var personWithAddress = new PersonWithAddress
        {
            Name = "John Daffali",
            Age = 32,
            Address = new Address
            {
                Street = "123 Main St",
                City = "New York",
                State = "NY",
                ZipCode = "10001"
            }
        };
        collection.InsertOne(personWithAddress);

        // Update the person's address
        var filter = Builders<PersonWithAddress>.Filter.Eq(p => p.Name, "John Daffali");
        var update = Builders<PersonWithAddress>.Update.Set(p => p.Address.City, "Los Angeles");
        collection.UpdateOne(filter, update);

        // Delete the person with address
        collection.DeleteOne(filter);

        // Verify deletion
        var deletedPersonWithAddress = collection.Find(filter).FirstOrDefault();
        Console.WriteLine(deletedPersonWithAddress == null ? "Person with address deleted successfully." : "Failed to delete person with address.");
    }
}