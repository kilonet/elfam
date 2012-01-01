<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<elfam.web.Models.Comment>>" %>
<%@ Import Namespace="elfam.web" %>
<% if (Model.Count() > 0) {%>
<script type="text/javascript">
    $(function() {
        $('.del_comment').click(function() {
            if (confirm('Удалить комментарий?')) {
                $.post('/Product/RemoveComment/', { id: $(this).attr('id') }, function() {
                    flash('Комментарий удалён. Чтобы увидеть изменения перезагрузите страницу.');
                })
            };
        });
    })
</script>
<h3>Отзывы</h3>
<table>

<% foreach(var comment in Model) {%>
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
<% } %>


