using Microsoft.AspNetCore.Mvc;

namespace Analyzer.DB.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return new RedirectResult("~/swagger");
		}
	}
}
