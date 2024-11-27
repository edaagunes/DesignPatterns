namespace DesignPattern.CQRS.CQRSPattern.Queries
{
	public class GetProductByIdQuery
	{
		public GetProductByIdQuery(int id)
		{
			Id = id;
		}

		// Sorgulama id ye göre olacak
		public int Id { get; set; }
	}
}
