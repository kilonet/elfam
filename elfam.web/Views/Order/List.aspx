<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.Paging.SearchResults<elfam.web.Models.Order>>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Models" %>
<%@ Import Namespace="elfam.web.Paging.Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Заказы
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Заказы</h2>
        
        <% foreach (OrderStatus status in Enum.GetValues(typeof(OrderStatus))) {%>
            <% bool highlight = (Model.Criteria as OrderListSearchCriteria).Status == status; %>
            <% string cssClass = highlight ? "class='status-highlight'" : "";%>
            <a <%= cssClass %> href="<%= Model.Criteria.Link((Model.Criteria as OrderListSearchCriteria).WithStatus(status))%>"><%= status.Description(status)%></a>  
        <% } %>
        
    
    <% if (Model.Results.Count() > 0) {%>
    <table class="box-table-b">
        <tr>
            <th></th>
            <th><%= Model.Criteria.Header("Пользователь", "user")%></th>
            <th><%= Model.Criteria.Header("Дата", "date")%></th>
            <th><%= Model.Criteria.Header("Сумма", "summ")%></th>
            <th><%= Model.Criteria.Header("Доход", "profit")%></th>
            <th><%= Model.Criteria.Header("Способ оплаты", "payment")%></th>
            <th><%= Model.Criteria.Header("Способ доставки", "deliver")%></th>
            <th><%= Model.Criteria.Header("Город", "city")%></th>
            <th><%= Model.Criteria.Header("Статус", "status")%></th>
            <%--<th></th>--%>
        </tr>

    <% foreach (var item in Model.Results) { %>
    
        <tr>
            <td><a href="/Order/Details/<%= item.Uid %>">...</a></td>
            <td><%= item.User.Email %></td>
            <td><%= item.Date.ToString("d") %></td>
            <td><%= item.Total().ToString("C0") %></td>
            <td><%= item.Profit.ToString("C0") %></td>
            <td><%= item.PaymentType.Description(item.PaymentType)%></td>
            <td><%= item.DeliverType.Description(item.DeliverType) %></td>
            <td><%= item.ShippingDetails.City %></td>
            <td><%= item.Status.Description(item.Status) %></td>
            <%-- <td>
                <form action="/Order/Revert" method="post">
                    <input name="id" type="hidden" value="<%= item.Id %>"/>
                    <input type="submit" value="откатить"/>
                </form>
            </td>--%>
        </tr>
    
    <% } %>

    </table>
    
    <%= Model.Criteria.Pages(Model.PageCount) %>
    <%} else {%>
        Нет заказов
    <%} %>
</asp:Content>

