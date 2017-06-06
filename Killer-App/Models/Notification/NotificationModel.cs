using System.Collections.Generic;
using Killer_App.Helpers.Providers;

namespace Killer_App.Models.Notification
{
    public class NotificationModel : BaseModel
    {
        public List<Helpers.Objects.Notification> Notifications { get; set; }

        public NotificationModel()
        {}

        public NotificationModel(Provider provider)
        {
            Provider = provider;
            Notifications = Provider.UserProvider.GetNotifications();
        }
    }
}