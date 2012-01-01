<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.Paging.SearchResults<elfam.web.Models.Comment>>" %>
<%@ Import Namespace="elfam.web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	- Комментарии
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Отзывы</h2>
    <a href="/Comment/Add">Оставить отзыв</a>
<% if (Model.Results.Count() > 0) {%>
<script type="text/javascript">
    $(function() {
        $('.del_comment').click(function() {
            if (confirm('Удалить комментарий?')) {
                $.post('/Comment/RemoveComment/', { id: $(this).attr('id') }, function() {
                    flash('Комментарий удалён. Чтобы увидеть изменения перезагрузите страницу.');
                })
            };
        });
    })
</script>

<table>

<% foreach(var comment in Model.Results) {%>
<tr>
    <td valign="top"> <% if (comment.Image != null) {%> 
        <a rel="lightbox" href="<%=ResolveClientUrl(comment.Image.PathRootBasedBig) %>">
            <%= comment.Image.AsTagSmall(this) %>
        </a>
    <% } else {%> 
        <img src="<%= ResolveClientUrl("~/Content/Uploads/siluet.jpg") %>"/>
    <% } %>
    </td>
    <td>
    <%= comment.User.Contact.Name %>, <%= comment.User.Contact.City %>, <%= comment.Date.ToShortDateString() %><br /><br />
    <%= comment.Text%>
    <% if (UserContext.IsAdmin()) {%>
        <input type="button" value="Удалить комментарий" id="<%= comment.Id %>" class="del_comment"/>
    <% } %>
    </td>
    
</tr>

<% } %>
</table>
<%= Model.Criteria.Pages(Model.PageCount) %>
<% } %>
</asp:Content>
