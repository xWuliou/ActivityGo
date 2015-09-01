using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivityGo.Models;
using ActivityGo.Utities;
using MongoDB.Driver;

namespace ActivityGo.DataService
{
  public class ActivityService : IActivityService
  {
    private DBService dbService = new DBService();
    private FilterDefinitionBuilder<Activity> filterBuilder = Builders<Activity>.Filter;

    public void CreateActivity(Activity activity)
    {
      activity.ID = Guid.NewGuid().ToString();
      activity.CreateTime = DateTime.Now;
      activity.UpDateTime = DateTime.Now;
      activity.ValidStatus = (int) ValidStatus.TRUE;
        dbService.Add<Activity>(activity);
    }

    public Activity UpdateActivity(Activity activity)
    {
      var filter = filterBuilder.Where(x => x.ID == activity.ID);
      activity.CreateTime = dbService.Query(filter).Result[0].CreateTime;
      activity.ID = dbService.Query(filter).Result[0].ID;
      activity.UpDateTime = DateTime.Now;
      var result = dbService.Update(filter, activity).Result;
      if (result.IsModifiedCountAvailable && result.ModifiedCount == 1)
      {
        return dbService.Query(filter).Result[0];
      }
      else
      {
        return new Activity();
      }
    }

    public Activity GetActivity(string activityID)
    {
      var filter = filterBuilder.Where(x => x.ID == activityID);
      var result = dbService.Query(filter).Result;
      if (result.Count > 0)
      {
        return result[0];
      }
      else
      {
        return new Activity();
      }
    }
  }
}