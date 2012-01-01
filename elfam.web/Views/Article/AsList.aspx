<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IList<elfam.web.Models.Article>>" %>
<ul>
<% foreach (var a in Model) { %>
    <li><a href="/Article/Details/<%= a.Id %>"><%= a.Title %></a></li>
<% } %>
<li><a href="/Comment/">Отзывы</a></li>
<li><a href="/Home/News/">Новости</a></li>
<li><a href="http://blog.elfam.ru/">Блог</a></li>
</ul>