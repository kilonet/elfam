using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Paging
{
    public class NameValue
    {
        public NameValue(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Name + "=" + Value;
        }
    }
}
