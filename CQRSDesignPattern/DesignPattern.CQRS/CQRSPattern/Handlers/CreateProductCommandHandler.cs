using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
	public class CreateProductCommandHandler
	{
		private readonly Context _context;

		public CreateProductCommandHandler(Context context)
		{
			_context = context;
		}

		// Ekleme işleminde geriye bir değer döndürmeyecek, create command örnekleyeceği için parametre olarak alıcaz
		public void Handle(CreateProductCommand command)
		{
			_context.Products.Add(new Product
			{
				Name = command.Name,
				Description = command.Description,
				Price = command.Price,
				Status = true,
				Stock = command.Stock,
			});
			_context.SaveChanges();
		}
	}
}
