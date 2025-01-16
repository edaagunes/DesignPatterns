using DesignPattern.Decorator.DAL;
using DesignPattern.Decorator.DecoratorPattern2;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Decorator.Controllers
{
	public class DefaultController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Message message)
		{
			CreateNewMessage createNewMessage = new CreateNewMessage();
			createNewMessage.SendMessage(message);
			return View();
		}

		[HttpGet]
		public IActionResult Index2()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index2(Message message)
		{
			CreateNewMessage createNewMessage =new CreateNewMessage();
			EncryptoBySubjectDecorator encryptoBySubjectDecorator = new EncryptoBySubjectDecorator(createNewMessage);
			encryptoBySubjectDecorator.SendMessageByEncryptoSubject(message);
			return View();
		}


		[HttpGet]
		public IActionResult Index3()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index3(Message message)
		{
			CreateNewMessage createNewMessage = new CreateNewMessage();
			SubjectIdDecorator subjectIdDecorator = new SubjectIdDecorator(createNewMessage);
			subjectIdDecorator.SendMessageByIdSubject(message);
			return View();
		}
	}
}
