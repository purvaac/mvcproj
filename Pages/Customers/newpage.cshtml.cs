using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace mvcproj.Pages.Customers
{
    public class newpage : PageModel
    {
        private readonly ILogger<newpage> _logger;

        public newpage(ILogger<newpage> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}