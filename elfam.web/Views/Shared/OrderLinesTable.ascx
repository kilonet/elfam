<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<elfam.web.Models.Order>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Models" %>
    <table class="box-table-a">
        <tr>
            <th>Название</th>
            <th>Кол-во</th>
            <th>Цена</th>
        </tr>
    
    <% foreach (OrderLine line in Model.Lines) {%>
        <tr>
            <td><%= line.ProductName %></td>
            <td><%= line.Quantity %></td>
            <td><%= line.Price.ToCurrencyString() %></td>
        </tr>    
    <% } %> 
    <tr>
        <td></td><td>Сумма</td><td><%= Model.Summ.ToCurrencyString() %></td>
    </tr>
    <tr>
        <td></td><td>Сумма со скидкой <%= Model.Discount %>%</td><td><%= Model.SummWithDiscount.ToCurrencyString() %></td>
    </tr>
    <tr><td></td><td>Доставка <%= Model.Discount %></td><td><%= Model.DeliverPrice.ToCurrencyString() %></td></tr>
    <tr><td></td><td>Итого <%= Model.Discount %></td><td><%= Model.Total().ToCurrencyString() %></td></tr>
    </table>

