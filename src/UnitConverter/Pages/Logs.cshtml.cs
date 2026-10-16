using UnitConverter.Models;
using UnitConverter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverter.Models;
using UnitConverter.Services;

namespace UnitConverter.Pages
{
    /// <summary>
    /// Logs PageModel for displaying application logs.
    /// </summary>
    public class Logs : PageModel
    {
        private readonly ILogger<Logs> _logger;
        private readonly ILogReader _logReader;

        [BindProperty(SupportsGet = true)]
        public string Level { get; set; }
        public List<LogEntry> Entries { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? ConversionType { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? Search { get; set; }
        public string? Input { get; set; }
        public string? Output { get; set; }

        /// <summary>
        /// Logs Constructor, with injected objects.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="logReader"></param>
        public Logs(ILogger<Logs> logger, ILogReader logReader)
        {
            _logger = logger;
            _logReader = logReader;

            Level = string.Empty;
            Entries = new List<LogEntry>();
        }

        /// <summary>
        /// Load the logs and display them, filtering if requested.
        /// </summary>
        /// <returns>IActionResult of this page or redirect to the Error page</returns>
        public IActionResult OnGet()
        {
            try
            {
                LoadLogs();
            }
            catch (Exception e)
            {
                return RedirectToPage("/Error");
            }

            FilterLogs();

            return Page();
        }

        private void LoadLogs()
        {
            try
            {
                Entries = _logReader.Read().ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unable to load logs");
                throw;
            }
        }

        private void FilterLogs()
        {
            if (string.IsNullOrEmpty(Level)) // This being empty means show all logs
            {
                return;
            }



            // Counting backwards so removed elements don't throw off the elements being compared
            for (int i = Entries.Count - 1; i >= 0; i--)
            {
                if (!string.Equals(
                        Entries[i].Level,
                        Level,
                        StringComparison.OrdinalIgnoreCase))
                {
                    Entries.RemoveAt(i);
                }
            }

            /*  Alternative approach similar to Java's removeIf
            Entries.RemoveAll(entry =>
                !string.Equals(
                    Level,
                    entry.Level,
                    StringComparison.OrdinalIgnoreCase));
            */
        }
    }
}
