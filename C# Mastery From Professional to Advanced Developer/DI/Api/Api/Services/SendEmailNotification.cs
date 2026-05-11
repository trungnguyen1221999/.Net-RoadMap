namespace Api.Services
{
    public class SendEmailNotification : INotificationService
    {
        public void sendNotification(string email, string message)
        {
            // Simulate sending an email notification
            Console.WriteLine($"Email sent to {email}: {message}");
        }
    }
}