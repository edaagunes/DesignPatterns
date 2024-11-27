using DesignPattern.CQRS.CQRSPattern.Queries;
using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
	public class GetProductByIdQueryHandler
	{
		private readonly Context _context;

		public GetProductByIdQueryHandler(Context context)
		{
			_context = context;
		}

		// Id ye göre getirme işlemi
		public GetProductByIdQueryResult Handle(GetProductByIdQuery query)
		{
			var values = _context.Set<Product>().Find(query.Id);
			return new GetProductByIdQueryResult
			{
				Name = values.Name,
				Price = values.Price,
				ProductId = values.ProductId,
				Stock = values.Stock,
			};
		}
	}
}
