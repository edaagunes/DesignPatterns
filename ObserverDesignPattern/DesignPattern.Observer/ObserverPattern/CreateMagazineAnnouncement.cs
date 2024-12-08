using DesignPattern.Observer.DAL;
using System;

namespace DesignPattern.Observer.ObserverPattern
{
	public class CreateMagazineAnnouncement : IObserver
	{
		private readonly IServiceProvider _serviceProvider;
		Context context = new Context();

		public CreateMagazineAnnouncement(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}
		public void CreateNewUser(AppUser appUser)
		{
			context.UserProcesses.Add(new UserProcess
			{
				NameSurname = appUser.Name + " " + appUser.Surname,
				Magazine = "Bilim Dergisi",
				Content = "Bilim Dergimizin Mart Sayısı 1 Martta evinize ulaştırılacaktır, konular Jupiter Gezegeni ve Mars olacaktır."
			});
			context.SaveChanges();
		}
	}
}
