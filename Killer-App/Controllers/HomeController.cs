﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Killer_App.Helpers;

namespace Killer_App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var songs = new List<Song> {new Song(1, "Blue Moon", new TimeSpan(0, 3, 49)), new Song(2, "Stormy Wether",new TimeSpan(0, 4, 13))};
            ViewBag.Songs = songs;
            return View();
        }
    }
}