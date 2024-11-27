using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
	public class GetProductQueryHandler
	{
		private readonly Context _context;

		public GetProductQueryHandler(Context context)
		{
			_context = context;
		}

		// Entity'e ait verileri listelemek için query result tipinde dönmesi lazım
		// Result içerisindeki proplar ile entitydeki propları birbirleriyle eşleştiriyoruz
		public List<GetProductQueryResult> Handle()
		{
			var values = _context.Products.Select(x => new GetProductQueryResult
			{
				Id = x.ProductId,
				Price = x.Price,
				ProductName = x.Name,
				Stock = x.Stock,
			}).ToList();
			return values;
		}
	}
}
