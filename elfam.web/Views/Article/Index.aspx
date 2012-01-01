<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<IList<elfam.web.Models.Article>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	- Статьи
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Статьи</h2>
    <ul>
    <% foreach (var a in Model) {%>
        <li><a href="/Article/Details/<%= a.Id %>"><%= a.Title %></a> <a href="/Article/Edit/<%= a.Id %>">редактировать</a> <%= a.LastUpdated.ToLongDateString() %></li>
    <% } %>
    </ul>
</asp:Content>
