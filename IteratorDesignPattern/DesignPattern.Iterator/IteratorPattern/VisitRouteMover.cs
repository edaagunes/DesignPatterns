namespace DesignPattern.Iterator.IteratorPattern
{
	public class VisitRouteMover : IMover<VisitRoute>
	{
		public List<VisitRoute> visitRoutes = new List<VisitRoute>();

		// Yeni Route ekleme
		public void AddVisitRoute(VisitRoute visitRoute)
		{
			visitRoutes.Add(visitRoute);
		}

		// Ziyaret edilen rota sayisini tutmak icin 
		public int VisitRouteCount { get => visitRoutes.Count(); }

		public IIterator<VisitRoute> CreateIterator()
		{
			return new VisitRouteIterator(this);
		}
	}
}
