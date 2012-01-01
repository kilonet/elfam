<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.Paging.SearchResults<elfam.web.Models.Subscriber>>" %>
<%@ Import Namespace="elfam.web.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Подписчики
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Подписчики</h2>
    <% if (Model.Results.Count() > 0) {%>
    <table class="box-table-b">
    
    <tr>
        <th><%= Model.Criteria.Header("Email", "email") %></th>
        <th><%= Model.Criteria.Header("Подписан", "active") %></th>
    </tr>
        <% foreach (Subscriber subscriber in Model.Results){%>
            <tr>
                <td><%= subscriber.Email %></td>
                <td>
                    <input type="checkbox" <%= subscriber.IsActive ? "checked" : "" %>
                     id="email<%= subscriber.Id %>" onchange="handleSubscribe(<%= subscriber.Id %>)"  />
                    <span id="yesno<%= subscriber.Id %>"><%= subscriber.IsActive ? "да" : "нет"%></span>     
                </td>
            </tr>
        <% } %>
    </table>
    <%= Model.Criteria.Pages(Model.PageCount) %>
    <%} else {%>
        Нет подписчиков
    <%} %>
    <script type="text/javascript" language="javascript">
        function handleSubscribe(id) {
            $.post("/Subscriber/Subscribe", {
                id: id,
                subscribe: $("#email" + id).is(':checked')
            },
            function(id) {
                $("#yesno" + id).html($("#email" + id).is(':checked') ? "да" : "нет");
            })
        }
    </script>
</asp:Content>
