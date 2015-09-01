using System;
using System.Collections.Generic;

namespace ActivityGo.Models
{
  public class ActItem
  {
    public string ID { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public List<string> ActorList { get; set; }
    public string ActID { get; set; }
    public int IsCost { get; set; }
    public int Cost { get; set; }
    public List<Payment> Payments { get; set; }
    public string Creater { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime UpDateTime { get; set; }
    public int ValidStatus { get; set; }
  }

  public class Payment
  {
      public string UserID { get; set; }
      public int Cost { get; set; }
  }
}