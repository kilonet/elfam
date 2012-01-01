using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Paging
{
    public class WhereHqlBuilder
    {
        private List<string> wheres = new List<string>();
        private string select = "";

        public WhereHqlBuilder(string select, List<string> wheres)
        {
            if (string.IsNullOrEmpty(select))
                throw new ArgumentException("select is empty");
            if (wheres == null)
                throw new ArgumentException("conditions are empty");
            this.wheres = wheres;
            this.select = select;
        }

        public string Hql()
        {
            if (wheres.Count == 0)
                return select;
            string hql = " where ";
            int i = 0;
            foreach (string where in wheres)
            {
                string and = i == 0 ? " " : " and ";
                hql += and + where;
                i++;
            }
            return select + " " + hql;
        }
    }
}
