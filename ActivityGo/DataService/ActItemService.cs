using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivityGo.Models;
using ActivityGo.Utities;
using MongoDB.Driver;

namespace ActivityGo.DataService
{
  public class ActItemService : IActItemService
  {
    private DBService dbService = new DBService();
    private FilterDefinitionBuilder<ActItem> filterBuilder = Builders<ActItem>.Filter;

    public void CreateActItem(ActItem actItem)
    {
      actItem.CreateTime = DateTime.Now;
      actItem.UpDateTime = DateTime.Now;
      actItem.ValidStatus = (int)ValidStatus.TRUE;
      dbService.Add<ActItem>(actItem);
    }

    public ActItem UpdateActItem(ActItem actItem)
    {
      var filter = filterBuilder.Where(x => x.ID == actItem.ID);
      actItem.CreateTime = dbService.Query(filter).Result[0].CreateTime;
      actItem.UpDateTime = DateTime.Now;
      var result = dbService.Update<ActItem>(filter, actItem).Result;
      if (result.IsModifiedCountAvailable && result.ModifiedCount == 1)
      {
        return dbService.Query<ActItem>(filter).Result[0];
      }
      else
      {
        return new ActItem();
      }
    }

    public ActItem GetActItem(string actItemID)
    {
      var filter = filterBuilder.Where(x => x.ID == actItemID);
      var result = dbService.Query<ActItem>(filter).Result;
      if (result.Count > 0)
      {
        return result[0];
      }
      else
      {
        return new ActItem();
      }
    }

    public List<ActItem> GetActItemsByAct(string actId)
    {
      var filter = filterBuilder.Where(x => x.ActID == actId);
      var result = dbService.Query<ActItem>(filter).Result;
      return result;
    }

    public List<ActItem> GetCostItemsByAct(string actId)
    {
      var filter = filterBuilder.Where(x => x.ActID == actId&&x.IsCost ==1);
      var result = dbService.Query<ActItem>(filter).Result;
      return result;
    }

    public ActItem DeleteActItem(ActItem actItem)
    {
      var filter = filterBuilder.Where(x => x.ID == actItem.ID);
      actItem.CreateTime = dbService.Query(filter).Result[0].CreateTime;
      actItem.ID = dbService.Query(filter).Result[0].ID;
      actItem.UpDateTime = DateTime.Now;
      actItem.ValidStatus = (int) ValidStatus.FALSE;
      var result = dbService.Update<ActItem>(filter, actItem).Result;
      if (result.IsModifiedCountAvailable && result.ModifiedCount == 1)
      {
        return dbService.Query(filter).Result[0];
      }
      else
      {
        return new ActItem();
      }
    }
  }
}