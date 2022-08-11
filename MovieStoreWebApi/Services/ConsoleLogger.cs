namespace MovieStoreWebApi.Services{
    public class ConsoleLogger : ILoggerServices
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] - {0}",message);
        }
    }
}