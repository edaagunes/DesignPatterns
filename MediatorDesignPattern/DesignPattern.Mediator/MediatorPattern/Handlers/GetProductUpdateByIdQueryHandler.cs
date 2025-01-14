using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.MediatorPattern.Queries;
using DesignPattern.Mediator.MediatorPattern.Results;
using MediatR;
using NuGet.Protocol.Plugins;

namespace DesignPattern.Mediator.MediatorPattern.Handlers
{
	public class GetProductUpdateByIdQueryHandler : IRequestHandler<GetProductUpdateByIdQuery, UpdateProductByIdQueryResult>
	{
		private readonly Context _context;

		public GetProductUpdateByIdQueryHandler(Context context)
		{
			_context = context;
		}

		public async Task<UpdateProductByIdQueryResult> Handle(GetProductUpdateByIdQuery request, CancellationToken cancellationToken)
		{
			var values=await _context.Products.FindAsync(request.ProductId);
			return new UpdateProductByIdQueryResult
			{
				ProductId = values.ProductId,
				ProductName = values.ProductName,
				ProductCategory = values.ProductCategory,
				ProductPrice = values.ProductPrice,
				ProductStock = values.ProductStock,
				ProductStockType = values.ProductStockType,
			};
		}
	}
}
