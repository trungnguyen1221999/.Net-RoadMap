namespace Api.Services
{
    public interface INotificationService
    {
        void sendNotification(string email, string message);
    }
}