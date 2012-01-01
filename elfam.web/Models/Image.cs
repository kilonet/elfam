using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace elfam.web.Models
{
    public class Image: DomainEntity
    {
        public virtual string Small
        {
            get { return "small" + Id + ".jpg"; }
        }
        public virtual string Big
        {
            get { return "big" + Id + ".jpg"; }
        }

        public virtual string PathRootBasedBig { get { return Path.Combine(RootImageFolder + PathRootBased, Big); }  }
        public virtual string PathRootBasedSmall { get { return Path.Combine(RootImageFolder + PathRootBased, Small); }  }

        /// <summary>
        /// "Users/Category1/Subcategory"
        /// no trailing/forward slash
        /// </summary>
        public virtual string PathRootBased { get; set; }

        public static string RootImageFolder = "~/Content/Uploads/";

        public virtual string AsTagBig(System.Web.UI.Control userControl)
        {
            return string.Format("<img src=\"{0}\">", userControl.ResolveClientUrl(PathRootBasedBig));
        }
        public virtual string AsTagSmall(System.Web.UI.Control userControl)
        {
            return string.Format("<img src=\"{0}\">", userControl.ResolveClientUrl(PathRootBasedSmall));
        }

        public virtual void DeleteFiles(Controller controller)
        {
            File.Delete(controller.HttpContext.Server.MapPath(PathRootBasedBig));
            File.Delete(controller.HttpContext.Server.MapPath(PathRootBasedSmall));
        }
    }
}
