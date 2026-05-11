namespace Api.Services
{
    public class SendSmsNotification : INotificationService
    {
        public void sendNotification(string email, string message)
        {
            // Simulate sending an SMS notification
            Console.WriteLine($"SMS sent to {email}: {message}");
        }
    }
}