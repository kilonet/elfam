using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Utils
{
    public class ImageTestUtil
    {
        static Random random = new Random();
        public static string RandomImage()
        {
            string[] names = { "bfhs100", "cjxp100", "dear100", "lpyk100", "pdng100", "pjzz100", "xrji100", "yban100", "zaeh100", "zega100" };
            
            return names[random.Next(names.Length)];
        }
    }
}
