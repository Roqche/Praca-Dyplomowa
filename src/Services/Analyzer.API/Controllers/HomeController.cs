using Microsoft.AspNetCore.Mvc;

namespace Analyzer.API.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return new RedirectResult("~/swagger");
		}
	}
}
