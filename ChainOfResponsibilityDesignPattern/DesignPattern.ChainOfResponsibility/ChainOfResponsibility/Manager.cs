using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
	public class Manager : Employee
	{
		public override void ProcessRequest(CustomerProcessViewModel request)
		{
			Context context = new Context();

			if (request.Amount <= 250000)
			{
				CustomerProcess customerProcess = new CustomerProcess();
				customerProcess.Amount = request.Amount.ToString();
				customerProcess.Name = request.Name;
				customerProcess.EmployeeName = "Şube Müdürü - Hatice Sarı";
				customerProcess.Description = "Para Çekme İşlemi Onaylandı, Müşteriye Talep Ettiği Tutar Ödendi";

				context.CustomerProcesses.Add(customerProcess);
				context.SaveChanges();
			}

			else if (NextApprover != null)
			{
				CustomerProcess customerProcess = new CustomerProcess();
				customerProcess.Amount = request.Amount.ToString();
				customerProcess.Name = request.Name;
				customerProcess.EmployeeName = "Şube Müdürü - Hatice Sarı";
				customerProcess.Description = "Para Çekme Tutarı Şube Müdürünün Günlük Ödeyebileceği Limiti Aştığı İçin İşlem Bölge Müdürüne Yönlendirildi";

				context.CustomerProcesses.Add(customerProcess);
				context.SaveChanges();

				NextApprover.ProcessRequest(request);
			}
		}
	}
}
