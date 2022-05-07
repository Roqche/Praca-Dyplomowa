using Microsoft.AspNetCore.Mvc;

namespace RCP.DB.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return new RedirectResult("~/swagger");
		}
	}
}
