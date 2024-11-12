namespace DesignPattern.Iterator.IteratorPattern
{
	public class VisitRouteIterator : IIterator<VisitRoute>
	{
		private VisitRouteMover _visitRouteMover;
		public VisitRoute CurrentItem { get; set; }

		private int currentIndex = 0;

		public VisitRouteIterator(VisitRouteMover visitRouteMover)
		{
			_visitRouteMover = visitRouteMover;
		}

		public bool NextLocation()
		{
			if (currentIndex < _visitRouteMover.VisitRouteCount)
			{
				CurrentItem = _visitRouteMover.visitRoutes[currentIndex++];
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
