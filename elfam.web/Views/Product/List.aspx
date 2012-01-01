<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.ViewModels.ProductListViewModel>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Utils" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
- <%= Model.Category != null ? Model.Category.Name : "Товары" %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table class="category-header">
        <tr><td colspan="2"><h2>
            <% if (Model.IsNew) {%>
            Новинки
            <%} else {%>
            <%= Model.Category != null ? Model.Category.Name : "Товары" %>
            <% } %>
        </h2></td></tr>
        <tr>
            
            <td><%= Model.Category != null ? Html.CategoryImage(Model.Category.Image) : "" %></td>
            <td><%= Model.Category != null ? Model.Category.Description : "" %></td>
        </tr>
    </table>
    
    <div class="sort-headers">
        Сортировать по: 
        <%= Model.Results.Criteria.Header("названию", "name") %>
        <%= Model.Results.Criteria.Header("цене", "price")%>
        <%= Model.Results.Criteria.Header("дате поступления", "date")%>
        <%= Model.Results.Criteria.Header("категории", "category")%>
    </div>
    <table cellspacing="5" cellpadding="5">

    <% foreach (var product in Model.Results.Results) { %>
    
        <tr>
            <td rowspan="2"><%= Html.ProductImage(product)  %></td>
            <td colspan="3">
                <span class="product-name-list"><%= Html.ActionLink(product.Name, "Details", new {id = product.Id}) %></span><br />
                <span class="product-price-list">
                    <% if (product.IsAvailable) {%>
                        <%= Html.Encode(String.Format("{0:C0}", product.Price)) %>
                    <% } %>    
                </span><br/>
                <%= product.ShortDescription %>
            </td>
        </tr>
        <tr>
            <td>
                Размер
            </td>
            <td><%= product.Size %></td>
            <td>
                <% if(product.IsAvailable) {%>
                    <input type="hidden" id="productName<%= product.Id %>" value="<%= product.Name %>"/>
                    Кол-во:<input type="text" class="quantity-input" value="1" id="quantity<%= product.Id %>"/>
                    <span id="quantity<%= product.Id %>-val-message" class="field-validation-error"></span>
                    <input type="button" value="В корзину" onclick="addToCart(<%= product.Id %>)"/>
                <%} else {%>    
                    <span class="na">Временно нет в наличии</span>
                <%} %>
            </td>
        </tr>
        <tr><td style="height: 1.5em"></td></tr>
    <% } %>

    </table>

    <%= Model.Results.Criteria.Pages(Model.Results.PageCount) %>
    
    <link href="../../Content/gritter/css/jquery.gritter.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.gritter.min.js" type="text/javascript"></script>
</asp:Content>

