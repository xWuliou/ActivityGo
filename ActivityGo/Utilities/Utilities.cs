using System.Collections.Generic;

namespace ActivityGo.Utities
{
    public class Utilities
    {
        public static List<string> GetIdList<T>(List<T> listT)
        {
            dynamic listd = listT;
            List<string> listId = null;
            if (listT != null)
            {
                foreach (var d in listd)
                {
                    listId.Add(d.ID);
                }
            }
            return listId;
        }
    }

  public enum UserSouce
  {
    WebSite,
    Weixin,
    QQ,
    Weibo,
    Other
  }

  public enum ActivityType
  {
    lvyou,
    jucan,

  }

  public enum ValidStatus
  {
    TRUE = 1,
    FALSE = 0
  }
}