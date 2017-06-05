using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Killer_App.Helpers.Providers;

namespace Killer_App.Controllers
{
    public class QueueController : BaseController
    {
        public void Skip()
        {
            var provider = (Provider) Session["Provider"];
            if (provider == null) return;
            provider.QueueProvider.Skip();
        }
    }
}