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
    public class FormController : Controller {  

        private readonly ILogger<FormController> _logger;

        public FormController(ILogger<FormController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("form")]
        public ActionResult GetRawForm()
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

        [HttpGet]
        [Route("form/view")]
        public ActionResult GetFormView()
        {
            return View("FormTemplate");
        }

        [HttpPost]
        [Route("form")]
        public string JsonStringBody()
        {
            var requestHeaders = Request.Headers;
            var requestHeadersAsString = string.Join("\n", requestHeaders.Select(kv => kv.Key + " ===> " + kv.Value).ToArray());

            string requestBody;
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEndAsync();
                Console.WriteLine(body.Result);
                requestBody = body.Result;
            }

            return 
                $"Request headers:\n{ requestHeadersAsString }\n\n" +
                $"Request body:\n{ requestBody }";
        }
    }
}
