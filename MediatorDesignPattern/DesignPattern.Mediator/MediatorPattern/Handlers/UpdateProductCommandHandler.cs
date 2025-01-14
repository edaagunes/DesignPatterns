using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.MediatorPattern.Commands;
using MediatR;
using NuGet.Protocol.Plugins;

namespace DesignPattern.Mediator.MediatorPattern.Handlers
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
	{
		private readonly Context _context;

		public UpdateProductCommandHandler(Context context)
		{
			_context = context;
		}

		public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			var values=_context.Products.Find(request.ProductId);
			values.ProductName = request.ProductName;
			values.ProductPrice = request.ProductPrice;
			values.ProductStock= request.ProductStock;
			values.ProductStockType = request.ProductStockType;
			values.ProductCategory= request.ProductCategory;
			await _context.SaveChangesAsync();
		}
	}
}
