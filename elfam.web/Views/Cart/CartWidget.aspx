<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<elfam.web.Models.Cart>" %>
<%@ Import Namespace="elfam.web" %>
<%@ Import Namespace="elfam.web.Extensions" %>

<h2>Корзина</h2>
    <% if (Model.Items.Count < 1) {%>
        В корзине пусто
    <% } else {%>
    <table class="cart box-table-a">
        <tr>
            <th>Товар</th><th>Цена</th>
        </tr>
        <% foreach (var item in Model.Items) {%>
            <tr>
                <td><%= item.Product.Name %> x <%= item.Quantity %> шт.</td><td><%= item.Summ().ToCurrencyString() %></td>
            </tr>  
        <% } %>
        <tr><td class="cart-summ">Сумма</td><td><%= Model.Summ().ToCurrencyString() %></td></tr>
        <tr><td class="cart-summ">Сумма со скидкой <%= UserContext.Discount() %> + <%= Model.CurrentDiscount() %>%</td><td><%= Model.SummDiscount().ToCurrencyString() %></td></tr>
    </table>
    <a href="/Cart/">содержимое корзины</a>
    
    <% } %>
