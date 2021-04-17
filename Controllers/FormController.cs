using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetMiniBe.Controllers
{
    [ApiController]
    [Route("api")]
    public class FormController : ControllerBase
    {
        private readonly ILogger<FormController> _logger;

        public FormController(ILogger<FormController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("form")]
        public ActionResult Index()
        {
            string form = "<html>" 
                + "<head><title>Form demo</title></head>" 
                + "<body>"
                + "<form action=\"\" method=\"POST\">"
                + "<label for=\"firstname\">Firstname:</label><br>"
                + "<input type=\"text\" name=\"firstname\"><br>"
                + "<label for=\"lastname\">Lastname:</label><br>"
                + "<input type=\"text\" name=\"lastname\"><br>"
                + "<input type=\"submit\" value=\"Send\">"
                + "</form>"
                + "</body>" 
                + "</html>";
            return Content(form, "text/html");
        }

        [HttpPost]
        [Route("form")]
        public string JsonStringBody()
        {
            string resp;
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEndAsync();
                Console.WriteLine(body.Result);
                resp = body.Result;
            }

            return resp;
        }
    }
}
