namespace IT.Service.Management.UI.Shared.Models;

public class NotificationModel
{
    public string Id { get; set; }

    public NotificationType Type { get; set; }

    public string Message { get; set; }

    public bool AutoClose { get; set; }

    public bool KeepAfterRouteChange { get; set; }

    public bool Fade { get; set; }
}