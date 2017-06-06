using Killer_App.Helpers.Providers;

namespace Killer_App.Controllers
{
    public class QueueController : BaseController
    {
        public void Skip()
        {
            var provider = (Provider) Session["Provider"];
            provider?.QueueProvider.Skip();
        }
    }
}