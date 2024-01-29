using NotificationService.Interfaces;

namespace NotificationService.Implements
{
    public class TestService : ITestService
    {
        public bool SendMessage(string message)
        {
            return true;
        }
    }
}
