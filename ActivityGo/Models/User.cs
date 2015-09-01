using System;

namespace ActivityGo.Models
{

  public class User
  {
    public string ID { get; set; }
    public string Name { get; set; }
    public string NickName { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Source { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime UpDateTime { get; set; }
    public int ValidStatus { get; set; }
  }

    
}