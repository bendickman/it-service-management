using IT.Service.Management.UI.Shared.Models;

namespace IT.Service.Management.UI.Shared.Services;

public interface INotificationService
{
    event Action<NotificationModel> OnAlert;

    void Success(string message, bool keepAfterRouteChange = false, bool autoClose = true);

    void Error(string message, bool keepAfterRouteChange = false, bool autoClose = true);

    void Info(string message, bool keepAfterRouteChange = false, bool autoClose = true);

    void Warning(string message, bool keepAfterRouteChange = false, bool autoClose = true);

    void Alert(NotificationModel alert);

    void Clear(string? id = null);
}
