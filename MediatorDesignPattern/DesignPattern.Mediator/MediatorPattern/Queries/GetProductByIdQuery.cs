using DesignPattern.Mediator.MediatorPattern.Results;
using MediatR;

namespace DesignPattern.Mediator.MediatorPattern.Queries
{
	public class GetProductByIdQuery : IRequest<GetProductByIdQueryResult>
	{
		public int ProductId { get; set; }

		public GetProductByIdQuery(int productId)
		{
			ProductId = productId;
		}
	}
}
