using IT.Service.Management.UI.Shared.Models;

namespace IT.Service.Management.UI.Shared.Services;

public class NotificationService : INotificationService
{
    private const string _defaultId = "default-alert";

    public event Action<NotificationModel>? OnAlert;

    public void Success(
        string message,
        bool keepAfterRouteChange = false,
        bool autoClose = true)
    {
        Alert(new NotificationModel
        {
            Type = NotificationType.Success,
            Message = message,
            KeepAfterRouteChange = keepAfterRouteChange,
            AutoClose = autoClose,
        });
    }

    public void Error(
        string message,
        bool keepAfterRouteChange = false,
        bool autoClose = true)
    {
        Alert(new NotificationModel
        {
            Type = NotificationType.Error,
            Message = message,
            KeepAfterRouteChange = keepAfterRouteChange,
            AutoClose = autoClose,
        });
    }

    public void Info(
        string message,
        bool keepAfterRouteChange = false,
        bool autoClose = true)
    {
        Alert(new NotificationModel
        {
            Type = NotificationType.Info,
            Message = message,
            KeepAfterRouteChange = keepAfterRouteChange,
            AutoClose = autoClose,
        });
    }

    public void Warning(
        string message,
        bool keepAfterRouteChange = false,
        bool autoClose = true)
    {
        Alert(new NotificationModel
        {
            Type = NotificationType.Warning,
            Message = message,
            KeepAfterRouteChange = keepAfterRouteChange,
            AutoClose = autoClose,
        });
    }

    public void Alert(
        NotificationModel alert)
    {
        alert.Id = alert.Id ?? _defaultId;
        OnAlert?.Invoke(alert);
    }

    public void Clear(
        string? id = _defaultId)
    {
        OnAlert?.Invoke(new NotificationModel { Id = id! });
    }
}
