using System.Collections.Generic;

namespace elfam.web.Paging
{
    public class SearchResults<T>
    {
        public int PageCount { get; private set; }
		public SearchCriteria Criteria { get; private set; }
		public IEnumerable<T> Results { get; private set; }

		public SearchResults(int pageCount, SearchCriteria criteria, IEnumerable<T> results)
		{
			PageCount = pageCount;
			Criteria = criteria;
			Results = results;
		}
    }
}
