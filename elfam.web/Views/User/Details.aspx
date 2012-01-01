<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.Models.User>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Информация о пользователе
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Информация о пользователе</h2>
    <% Html.RenderPartial("UserDetailsForAdmin", Model); %>
    
    
    
    <% foreach(Order order in Model.Orders) {%>
        <h3>Заказ №<%= order.Id %> от <%= order.Date.ToLongDateString() %></h3>
        <table class="box-table-b">
            <tr>
                <th>Фото</th>
                <th>Товар</th>
                <th>Цена</th>
                <th>Кол-во</th>
                <th>Сумма (со скидкой <%= order.Discount %>%)</th>
                <th>Прибыль</th>
            </tr>
            <% foreach (OrderLine line in order.Lines) {%>
                <tr>
                    <td><%= Html.ProductImage(line.Product) %></td>
                    <td><%= line.ProductName %></td>
                    <td><%= line.Price.ToCurrencyString() %></td>
                    <td><%= line.Quantity %></td>
                    <td><%= line.SummWithDiscount.ToCurrencyString()%></td>
                    <td><%= line.Profit.ToCurrencyString() %></td>
                </tr>
            <%} %>
            <tr>
                <td colspan="4">Итого</td>
                <td><%= order.SummWithDiscount.ToCurrencyString() %></td>
                <td><%= order.Profit.ToCurrencyString() %></td>
            </tr>
        </table>
    <%} %>
    <a href="/User/List/">назад к списку пользователей</a>
</asp:Content>
