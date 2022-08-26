using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SignalRListener.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IConfiguration _config;
        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void OnGet()
        {
            ViewData["HubUrl"] = _config["HubUrl"];
        }
    }
}