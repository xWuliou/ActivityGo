using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivityGo.Models;

namespace ActivityGo.DataService
{
    public interface IUserService
    {
      User RegisterUser(User user);
      void RegisterUsers(List<User> users);
      User GetUserByName(string username);
      User Login(User user);
      User GetUser(string userID);
      User UpdateUser(User user);
      User DeleteUser(User user);
    }


  public interface IActivityService
  {
    void CreateActivity(Activity activity);
    Activity UpdateActivity(Activity activity);
    Activity GetActivity(string activityID);
  }

  public interface IActItemService
  {
    void CreateActItem(ActItem actItem);
    ActItem UpdateActItem(ActItem actItem);
    ActItem GetActItem(string actItemID);
    List<ActItem> GetActItemsByAct(string actId);
    List<ActItem> GetCostItemsByAct(string actId);
    ActItem DeleteActItem(ActItem actItem);
  }
}