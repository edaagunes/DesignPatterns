using DesignPattern.Observer.DAL;
using DesignPattern.Observer.Models;
using DesignPattern.Observer.ObserverPattern;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesignPattern.Observer.Controllers
{
	public class DefaultController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ObserverObject _observerObject;

		public DefaultController(UserManager<AppUser> userManager, ObserverObject observerObject)
		{
			_userManager = userManager;
			_observerObject = observerObject;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
		{
			var appUser = new AppUser()
			{
				Name = registerViewModel.Name,
				Email = registerViewModel.Email,
				Surname = registerViewModel.Surname,
				UserName = registerViewModel.Username
			};

			var result= await _userManager.CreateAsync(appUser,registerViewModel.Password);

			if (result.Succeeded)
			{
				_observerObject.NotifyObserver(appUser);
				return View();
			}

			return View();
		}
	}
}
