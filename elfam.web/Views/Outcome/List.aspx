<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<elfam.web.ViewModels.OutcomeListItemViewModel>>" %>
<%@ Import Namespace="elfam.web.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Расходы
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Расходы</h2>
    <% if (Model.Count() > 0) {%>
    <table class="box-table-b">
        <tr>
            <th>Картинка</th>
            <th>Товар</th>
            <th>Цена</th>
            <th>Количество</th>
            <th>Строка заказа</th>
            <th>Приход</th>
            <th>Дата</th>
        </tr>
        
        <% foreach(var item in Model) {%>
            <tr>
                <td><%= Html.ProductImage(item.Product) %></td>
                <td><a href="/Product/Details/<%= item.ProductId %>"><%= item.ProductName  %></a></td>
                <td><%= item.SellPrice.ToString("C")  %></td>
                <td><%= item.Quantity  %></td>
                <td><%= item.OrderLineId  %></td>
                <td><%= item.IncomeId  %></td>
                <td><%= item.Date.ToShortDateString()  %></td>
            </tr>
        <% } %>
        <%} else {%>
        Нет расходов
    <%} %>
    </table>

</asp:Content>
