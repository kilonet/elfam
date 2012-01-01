using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Attributes
{
    class Description : Attribute
    {

        public string Text;

        public Description(string text)
        {

            Text = text;

        }

    }
}
