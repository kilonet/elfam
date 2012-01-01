<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" 
Inherits="System.Web.Mvc.ViewPage<IEnumerable<elfam.web.ViewModels.User.UserListItemViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Все пользователи
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Все пользователи</h2>

    <table class="box-table-b">
        <tr>
            <th>Ф.И.О.</th>
            <th>Заказы</th>
            <th>Сумма</th>
            <th>Доход</th>
            <th>Подписан</th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td><a href="/User/Details/<%= item.User.Id %>"><%= Html.Encode(item.User.Contact.FullName)%></a></td>
            <td><%= Html.ActionLink(item.Quantity.ToString(), "List", "Order", new { user = item.User.Id }, null)%></td>
            <td><%= item.Summ.ToString("C") %></td>
            <td><%= item.Profit.ToString("C") %></td>
            <td>
                <input type="checkbox" <%= item.User.IsSignedForNews ? "checked" : "" %>
                    id="email<%= item.User.Id %>" onchange="handleSubscribe(<%= item.User.Id %>)"  />
                <span id="yesno<%= item.User.Id %>"><%= item.User.IsSignedForNews ? "да" : "нет"%></span>
            </td>
        </tr>
    
    <% } %>

    </table>
    <script type="text/javascript" language="javascript">
        function handleSubscribe(id) {
            $.post("/User/SubscribeUser", {
                id: id,
                subscribe: $("#email" + id).is(':checked')
            },
            function(id) {
                $("#yesno" + id).html($("#email" + id).is(':checked') ? "да" : "нет");
            })
        }
    </script>
</asp:Content>

