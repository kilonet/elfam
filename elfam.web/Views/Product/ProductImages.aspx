<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<elfam.web.Models.Product>" %>

<% foreach(elfam.web.Models.Image image in Model.Images) {%>
    <a href="<%= ResolveClientUrl("~/Content/Uploads/") + image.Big%>">
        <img src="<%= ResolveClientUrl("~/Content/Uploads/") + image.Small%>"/>
    </a>
    <%= Html.ActionLink("[удалить]", "DeleteImage", new { imageId = image.Id, productId = Model.Id}) %><br />
<% } %>
