<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<IList<elfam.web.Services.ProductReportRow>>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Models" %>
<%@ Import Namespace="elfam.web.Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Отчет по товарам
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Отчет по товарам</h2>
    <% if (Model.Count > 0) {%>
    <table class="box-table-b">
        <tr>
            <th>Товар</th>
            <th>Продано</th>
            <th>Отложено</th>
            <th>Чистая прибыль</th>
        </tr>
        <% foreach(ProductReportRow row in Model) {%>
    
        <tr>
            <td><%= row.Product.Name %></td>
            <td><%= row.PayedQuantity %></td>
            <td><%= row.ReservedQuantity %></td>
            <td><%= row.Profit.ToCurrencyString() %></td>
        </tr>
    
        <% } %>
    </table>
    <%} else {%>
        Нет отчета
    <%} %>


</asp:Content>
