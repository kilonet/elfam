<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<elfam.web.Models.Order>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Models" %>
<table class="box-table-b">
        <tr>
            <th>Картинка</th>
            <th>Название</th>
            <th>Кол-во</th>
            <th>Цена</th>
        </tr>
    
    <% foreach (OrderLine line in Model.Lines) {%>
        <tr>
            <td><%= Html.ProductImage(line.Product) %></td>
            <td><a target="_blank" href="/Product/Details/<%= line.Product.Id %>"><%= line.ProductName %></a></td>
            <td><%= line.Quantity %></td>
            <td><%= line.Price.ToCurrencyString() %></td>
        </tr>    
    <% } %> 
    <tr><td colspan="3">Сумма</td><td><%= Model.Summ.ToCurrencyString()%></td></tr>
    <tr><td colspan="3">Скидка <%= Model.Discount %>%</td><td><%= Model.DiscountSumm.ToCurrencyString()%></td></tr>
    <tr>
       <td colspan="3">Сумма со скидкой</td><td><%= Model.SummWithDiscount.ToCurrencyString() %></td>
    </tr>
    <tr>
       <td colspan="3">Доставка</td><td><%= Model.DeliverPrice.ToCurrencyString() %></td>
    </tr>
    <tr>
       <td colspan="3">Итого</td><td><%= Model.Total().ToCurrencyString() %></td>
    </tr>
    
    </table>

