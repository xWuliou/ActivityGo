using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using ActivityGo.Models;
using ActivityGo.Utities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ActivityGo.DataService
{
    public class UserService:IUserService
    {
      private DBService dbService = new DBService();
      private FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;
        

      public User RegisterUser(User user)
      {
        user.ID = Guid.NewGuid().ToString();
        user.CreateTime = DateTime.Now;
        user.UpDateTime = DateTime.Now;
        user.ValidStatus = (int) ValidStatus.TRUE;
        dbService.Add(user);
        return GetUser(user.ID);

      }

      public void RegisterUsers(List<User> users)
      {
        foreach (var user in users)
        {
          user.ID = Guid.NewGuid().ToString();
          user.CreateTime = DateTime.Now;
          user.UpDateTime = DateTime.Now;
          user.ValidStatus = (int) ValidStatus.TRUE;
        }
          dbService.Adds(users);
      }

      public User GetUserByName(string username)
      {
        var filter = filterBuilder.Where(x => x.Name == username);
        var result = dbService.Query(filter).Result;
        if (result.Count > 0)
        {
          return result[0];
        }
        else
        {
          return new User();
        }
      }

      public User Login(User user)
      {
        var username = user.Name;
        var password = user.Password;
        var filter = filterBuilder.Where(x => x.Name == username && x.Password == password);
        var result = dbService.Query(filter).Result;
        if (result.Count > 0)
        {
          return result[0];
        }
        else
        {
            return new User();
        }
      }

      public User GetUser(string userID)
      {
        var filter = filterBuilder.Where(x => x.ID == userID);
        var result = dbService.Query(filter).Result;
        if (result.Count > 0)
        {
          return result[0];
        }
        else
        {
          return new User();
        }
      }

      public User UpdateUser(User user)
      {
        var filter = filterBuilder.Where(x => x.ID == user.ID);
        user.ID = dbService.Query(filter).Result[0].ID;
        user.CreateTime = dbService.Query(filter).Result[0].CreateTime;
        user.UpDateTime = DateTime.Now;
        var result = dbService.Update(filter, user).Result;
        if (result.IsModifiedCountAvailable && result.ModifiedCount == 1)
        {        
          return dbService.Query(filter).Result[0];
        }
        else
        {
          return new User();
        }
      }

      public User DeleteUser(User user)
      {
        var filter = filterBuilder.Where(x => x.ID == user.ID);
        user = dbService.Query(filter).Result[0];
        user.UpDateTime = DateTime.Now;
        user.ValidStatus = 0;
        var result = dbService.Update(filter, user).Result;
        if (result.IsModifiedCountAvailable && result.ModifiedCount == 1)
        {
          return dbService.Query(filter).Result[0];
        }
        else
        {
          return new User();
        }
      }
    }
}