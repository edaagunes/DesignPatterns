namespace DesignPattern.CQRS.CQRSPattern.Results
{
	public class GetProductByIdQueryResult
	{
		// Id nin sonucunda gelecek proplar
		public int ProductId { get; set; }
		public string Name { get; set; }
		public int Stock { get; set; }
		public decimal Price { get; set; }
	}
}
