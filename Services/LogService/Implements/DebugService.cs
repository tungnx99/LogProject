using LogService.Interfaces;

namespace LogService.Implements
{
    public class DebugService : IDebugService
    {
        public void Debug(string message)
        {
            Console.WriteLine(message);
        }
    }
}
