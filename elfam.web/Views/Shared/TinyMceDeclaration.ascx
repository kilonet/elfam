<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<script src="<%= Url.Content("~/Scripts/ckeditor/ckeditor.js") %>" type="text/javascript"></script>
<script src="<%= Url.Content("~/Scripts/ckeditor/adapters/jquery.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        $().ready(function() {
            $('textarea').ckeditor();
        });
    </script>

