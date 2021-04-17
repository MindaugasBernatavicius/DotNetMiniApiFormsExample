using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetMiniBe.Controllers
{
    [Route("routes")]
    public class RoutesController : Controller
    {
        private readonly IActionDescriptorCollectionProvider _provider;

        public RoutesController(IActionDescriptorCollectionProvider provider)
        {
            _provider = provider;
            foreach (var item in _provider.ActionDescriptors.Items)
            {
                Console.WriteLine(item);
            }
        }

        [HttpGet]
        public IActionResult GetRoutes()
        {
            var routes = _provider.ActionDescriptors.Items.Select(x => new
            {
                Action = x.RouteValues["Action"],
                Controller = x.RouteValues["Controller"],
                //Name = x.AttributeRouteInfo.Name,
                //Template = x.AttributeRouteInfo.Template
            }).ToList();
            return Ok(routes);
        }
    }
}
