namespace DesignPattern.CQRS.CQRSPattern.Results
{
	public class GetProductQueryResult
	{
		// Sorgu sonucunda ilgili entity'e ait listelenecek propları belirttik
		public int Id { get; set; }
		public string ProductName { get; set; }
		public int Stock { get; set; }
		public decimal  Price { get; set; }
	}
}
