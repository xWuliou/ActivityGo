﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityGo.Models
{
  public class TransactionalInformation
  {
    public bool ReturnStatus { get; set; }
    public List<String> ReturnMessage { get; set; }
    public Hashtable ValidationErrors;
    public int TotalPages;
    public int TotalRows;
    public int PageSize;
    public Boolean IsAuthenicated;

    public TransactionalInformation()
    {
      ReturnMessage = new List<String>();
      ReturnStatus = true;
      ValidationErrors = new Hashtable();
      TotalPages = 0;
      TotalPages = 0;
      PageSize = 0;
      IsAuthenicated = false;
    }
  }
}