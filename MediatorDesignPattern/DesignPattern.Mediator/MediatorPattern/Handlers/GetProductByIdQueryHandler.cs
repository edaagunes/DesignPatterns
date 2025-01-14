using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.MediatorPattern.Queries;
using DesignPattern.Mediator.MediatorPattern.Results;
using MediatR;
using NuGet.Protocol.Plugins;

namespace DesignPattern.Mediator.MediatorPattern.Handlers
{
	public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
	{
		private readonly Context _context;

		public GetProductByIdQueryHandler(Context context)
		{
			_context = context;
		}

		public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
		{
			var values=await _context.Products.FindAsync(request.ProductId);
			return new GetProductByIdQueryResult
			{
				ProductId = values.ProductId,
				ProductName = values.ProductName,
				ProductStock = values.ProductStock,
			};
		}
	}
}
