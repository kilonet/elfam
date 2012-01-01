using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Paging.Comment
{
    [Serializable]
    public class CommentListSearchCriteria: SearchCriteria
    {
        public CommentListSearchCriteria()
        {
            this.SortExpression = "date";
            this.SortDirection = DescSearchOrder;
        }
    }
}
