using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ActivityGo.DataService
{
  public class DBService
  {

    private string connectionString = ConfigurationManager.AppSettings["connectionString"];
    private string dbName = ConfigurationManager.AppSettings["dbName"];

    protected static IMongoClient client;
    protected static IMongoDatabase database;

    public DBService()
    {
      client = new MongoClient(connectionString);
      database = client.GetDatabase(dbName);
    }


    public async void Add<T>(T t, string collectionName = "")
    {
      if (string.IsNullOrEmpty(collectionName))
      {
        collectionName = GetModelName<T>();
      }
      var collection = database.GetCollection<T>(collectionName);
      await collection.InsertOneAsync(t);

    }

    public async void Adds<T>(List<T> ts, string collectionName = "")
    {
      if (string.IsNullOrEmpty(collectionName))
      {
        collectionName = GetModelName<T>();
      }
      var collection = database.GetCollection<T>(collectionName);
      await collection.InsertManyAsync(ts);
    }

    public async Task<DeleteResult> Delete<T>(FilterDefinition<T> filter, string collectionName = "")
    {
      if (string.IsNullOrEmpty(collectionName))
      {
        collectionName = GetModelName<T>();
      }
      var collection = database.GetCollection<T>(collectionName);
      var result = await collection.DeleteOneAsync(filter);
      return result;
    }

    public async Task<ReplaceOneResult> Update<T>(FilterDefinition<T> filter, T t, string collectionName = "")
    {
      if (string.IsNullOrEmpty(collectionName))
      {
        collectionName = GetModelName<T>();
      }
      var collection = database.GetCollection<T>(collectionName);
      var result = await collection.ReplaceOneAsync(filter, t);
      return result;

    }

    public async Task<List<T>> Query<T>(FilterDefinition<T> filter, string collectionName = "")
    {
      if (string.IsNullOrEmpty(collectionName))
      {
        collectionName = GetModelName<T>();
      }
      var collection = database.GetCollection<T>(collectionName);
      var users = await collection.Find(filter).ToListAsync();
      return users;
    }


    private static string GetModelName<T>()
    {
      string[] arr = typeof (T).ToString().Split('.');
      Array.Reverse(arr);
      return arr[0];
    }

  }
}