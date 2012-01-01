<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<elfam.web.ViewModels.Income.IncomeListItemViewModel>>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Models" %>
<%@ Import Namespace="elfam.web.Paging" %>
<%@ Import Namespace="elfam.web.Paging.Income" %>
<%@ Import Namespace="elfam.web.ViewModels.Income" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Приходы
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script language="javascript" type="text/javascript">
    
    $(document).ready(function() { $('.box-table-b tr:odd').addClass('alt'); })

</script>
    <% var results = (SearchResults<Income>)ViewData["searchResult"]; %>
    <h2>Приходы</h2>

        <% var categories = (IEnumerable<Category>) ViewData["categories"]; %>
        <% bool highlight = Request.QueryString["CategoryId"] == null; %>
        <% string cssClass = highlight ? "class='status-highlight'" : "";%>
        <a <%= cssClass %> href="<%= results.Criteria.Link((results.Criteria as IncomeSearchCriteria).WithCategory(null))%>" >Всё</a> |
        <% foreach (var c in categories) {%>
        <% highlight = c.Id == Convert.ToInt32(Request.QueryString["CategoryId"]); %>
        <% cssClass = highlight ? "class='status-highlight'" : "";%>
        <a  <%= cssClass %> href="<%= results.Criteria.Link((results.Criteria as IncomeSearchCriteria).WithCategory(c))%>" ><%= c.Name %></a> |
        <%} %>
    
    <% if (Model.Count() > 0) {%>
    <table class="box-table-b">
        <tr>
            <th>Картинка</th>
            <th>Товар</th>
            <th>Артикул</th>
            <th>Кол-во текущее</th>
            <th>Кол-во начальное</th>
            <th>Дата</th>
            <th>Цена закупки</th>
            <th></th>
        </tr>
    
    <% foreach (IncomeListItemViewModel item in Model) {%>
  
    <tr>
        <td><%= Html.ProductImage(item.Product) %></td>
        <td><a href="/Product/Details/<%= item.ProductId %>"><%= item.ProductName %> (id=<%= item.ProductId %>)</a></td>
        <td><%= item.SKU %></td>
        <td><%= item.QuantityCurrent %></td>
        <td><%= item.QuantityInitial %></td>
        <td><%= item.Date.ToShortDateString() %></td>
        <td><%= item.BuyPrice.ToCurrencyString() %></td>
        <td><a href="/Income/Edit/<%= item.Id %>">редактировать</a></td>
    </tr>
    
    <% } %>
    
    </table>
    
    
    <%= results.Criteria.Pages(results.PageCount) %>
    
    <%} else {%>
        Нет приходов
    <%} %>
</asp:Content>
