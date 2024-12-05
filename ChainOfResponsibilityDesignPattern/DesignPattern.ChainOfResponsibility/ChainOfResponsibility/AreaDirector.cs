using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
	public class AreaDirector : Employee
	{
		public override void ProcessRequest(CustomerProcessViewModel request)
		{
			Context context = new Context();

			if (request.Amount <= 400000)
			{
				CustomerProcess customerProcess = new CustomerProcess();
				customerProcess.Amount = request.Amount.ToString();
				customerProcess.Name = request.Name;
				customerProcess.EmployeeName = "Bölge Müdürü - Zeynep Yılmaz";
				customerProcess.Description = "Para Çekme İşlemi Onaylandı, Müşteriye Talep Ettiği Tutar Ödendi";

				context.CustomerProcesses.Add(customerProcess);
				context.SaveChanges();
			}

			// Zincirin Son Halkası
			else 
			{
				CustomerProcess customerProcess = new CustomerProcess();
				customerProcess.Amount = request.Amount.ToString();
				customerProcess.Name = request.Name;
				customerProcess.EmployeeName = "Bölge Müdürü - Zeynep Yılmaz";
				customerProcess.Description = "Para Çekme Tutarı Bölge Müdürünün Günlük Ödeyebileceği Limiti Aştığı İçin İşlem Gerçekleştirilemedi. Müşterinin Günlük Maksimum Çekebileceği Tutar 400.000₺ Olup Daha Fazlası İçin Birden Fazla Gün Şubeye Gelmesi Gereklidir";

				context.CustomerProcesses.Add(customerProcess);
				context.SaveChanges();
			}
		}
	}
}
