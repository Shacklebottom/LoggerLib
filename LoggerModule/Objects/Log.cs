namespace LoggerModule.Objects
{
    public class Log
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = new DateTime();

        public string Message { get; set; } = "";
    }
}
