using System;
using System.Collections.Generic;

namespace ActivityGo.Models
{
  public class Activity
  {
    public string ID { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public string Creater { get; set; }
    public DateTime CreateTime   { get; set; }
    public DateTime UpDateTime { get; set; }
    public int ValidStatus { get; set; }
    public List<string> ActorList { get; set; }
  }


}