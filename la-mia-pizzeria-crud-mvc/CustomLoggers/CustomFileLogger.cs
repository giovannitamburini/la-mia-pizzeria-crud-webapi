namespace la_mia_pizzeria_crud_mvc.CustomLoggers
{
    public class CustomFileLogger : ICustomLogger
    {
        public void WriteLog(string message)
        {
            File.AppendAllText("C:\\Users\\giova\\source\\repos\\la-mia-pizzeria-crud-mvc\\la-mia-pizzeria-crud-mvc\\FileLogger.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} LOG: {message}\n");
        }
    }
}
