namespace MovieStoreWebApi.Services{
    public class DbLogger : ILoggerServices
    {
        public void Write(string message)
        {
            Console.WriteLine("[DbLogger] - {0}",message);
        }
    }
}