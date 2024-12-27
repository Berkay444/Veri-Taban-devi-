namespace ProductOrderManagementSystem.Utilities
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllText("logs.txt", message + Environment.NewLine);
        }
    }
}
