using System.Collections;
using System.Text.Json;
using UnitConverter.Models;

namespace UnitConverter.Services;

public class JsonLogReader : ILogReader
{
    private readonly string _logDirectory;

    public JsonLogReader(IWebHostEnvironment environment)
    {
        _logDirectory = Path.Combine(environment.ContentRootPath, "Logs");
    }

    public IEnumerable<LogEntry> Read()
    {
        string[] logFiles = Directory.GetFiles(_logDirectory, "*.json");
        ArrayList logEntries = new ArrayList();

        foreach (string logfile in logFiles)
        {
            string[] lines = File.ReadAllLines(logfile);

            foreach (string line in lines)
            {
                LogEntry? entry = JsonSerializer.Deserialize<LogEntry>(line);
                if (entry != null)
                {
                    logEntries.Add(entry);
                }
            }
        }

        return logEntries.Cast<LogEntry>();
    }
}
