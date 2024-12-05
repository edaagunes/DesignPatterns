using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
	// Veznedar
	public class Treasurer : Employee
	{
		public override void ProcessRequest(CustomerProcessViewModel request)
		{
			Context context = new Context();

			// Eğer istenilen tutar 100.000 ₺ ise işlemi onayla
			if (request.Amount <= 100000)
			{ 
				CustomerProcess customerProcess = new CustomerProcess();
				customerProcess.Amount=request.Amount.ToString();
				customerProcess.Name=request.Name;
				customerProcess.EmployeeName = "Veznedar - Ayşe Çınar";
				customerProcess.Description="Para Çekme İşlemi Onaylandı, Müşteriye Talep Ettiği Tutar Ödendi";
				
				context.CustomerProcesses.Add(customerProcess);
				context.SaveChanges();
			}

			// Değil ise işlemi bir sonraki halkaya/kişiye yönlendir. Zincirin sonraki halkası var ise!
			else if(NextApprover != null)
			{
				CustomerProcess customerProcess=new CustomerProcess();
				customerProcess.Amount = request.Amount.ToString();
				customerProcess.Name=request.Name;
				customerProcess.EmployeeName = "Veznedar - Ayşe Çınar";
				customerProcess.Description = "Para Çekme Tutarı Veznedarın Günlük Ödeyebileceği Limiti Aştığı İçin İşlem Şube Müdür Yardımcısına Yönlendirildi";

				context.CustomerProcesses.Add(customerProcess);
				context.SaveChanges();
				
				NextApprover.ProcessRequest(request);
			}
		}
	}
}
