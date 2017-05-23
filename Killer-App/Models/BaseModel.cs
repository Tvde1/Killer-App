﻿using System.Web.UI;
using Killer_App.App_Data.Providers;

namespace Killer_App.Models
{
    public class BaseModel
    {
        public Provider Provider { get; set; }
        public string Error { get; set; }
        public string Sucess { get; set; }
        public string Warning { get; set; }
    }
}