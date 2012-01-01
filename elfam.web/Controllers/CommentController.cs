using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elfam.web.Attributes;
using elfam.web.Models;
using elfam.web.Paging.Comment;
using elfam.web.Utils;
using Wiki;

namespace elfam.web.Controllers
{
    public class CommentController : BaseController
    {
        //
        // GET: /Comment/

        public ActionResult Index(CommentListSearchCriteria criteria)
        {
            CommentListQueryBuilder queryBuilder = new CommentListQueryBuilder(criteria);
            var result = queryBuilder.Execute(daoTemplate.Session);
            return View(result);
        }

        public ActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(string text)
        {
            // text 
            if (text.Trim().Length == 0)
            {
                return Redirect("/Comment/");
            }
            Comment comment = new Comment();
            CreoleParser parser = new CreoleParser();
            comment.Text = parser.ToHTML(HttpUtility.HtmlEncode(text.Replace(Environment.NewLine, "\\\\")));
            comment.User = CurrentUser();

            // upload

            foreach (string inputTagName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[inputTagName];
                if (file.ContentLength == 0) continue;
                Image image = new Image();
                image.PathRootBased = "Users";
                daoTemplate.Save(image);
                string filePath = HttpContext.Server.MapPath(image.PathRootBasedBig);
                string thumbFilePath = HttpContext.Server.MapPath(image.PathRootBasedSmall);
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                file.SaveAs(filePath);
                ImageUtils.SaveImageToFile(ImageUtils.ResizeImage(filePath, 640), filePath);
                ImageUtils.SaveImageToFile(ImageUtils.ResizeImageSquare(filePath, 100), thumbFilePath);


                comment.Image = image;
                daoTemplate.Save(image);

            }
            daoTemplate.Save(comment);
            return Redirect("/Comment/");
        }


        [HttpPost]
        [Admin]
        public ActionResult RemoveComment()
        {
            int id = Convert.ToInt32(Request.Form["id"]);
            Comment comment = daoTemplate.FindByID<Comment>(id);
            if (comment.Image != null)
                comment.Image.DeleteFiles(this);
            daoTemplate.Remove(comment);
            return Content("");
        }

    }
}
