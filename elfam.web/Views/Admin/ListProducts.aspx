<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.ViewModels.Admin.ProductListViewModel>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Paging.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Список товаров
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Список товаров</h2>
    
    
    
    <select id="cat-select">
        <option value="-1">все категории</option>
        <% foreach (var category in Model.Categories) {%>
            <% int? categoryId = (Model.SearchResults.Criteria as ProductListAdminSearchCriteria).CategoryId; %>
            <% string selected = categoryId.HasValue && categoryId == category.Id ? "selected" : "";%>
            <option  <%= selected %> value="<%= Model.SearchResults.Criteria.Link((Model.SearchResults.Criteria as ProductListAdminSearchCriteria).WithCategoryId(category.Id)) %>">
                <%= category.Name %>
            </option>
            
        <% } %>
    </select>
    <input type="button" value="фильтр" id="btn-filter"/>
    <% if (Model.SearchResults.Results.Count() > 0) {%>
    <table class="box-table-b">
        <tr>
            <th>Картинка</th>
            <th><%= Model.SearchResults.Criteria.Header("Название", "p")%></th>
            <th><%= Model.SearchResults.Criteria.Header("Артикул", "sku")%></th>
            <th><%= Model.SearchResults.Criteria.Header("Категория", "category")%></th>
            <th><%= Model.SearchResults.Criteria.Header("Остаток", "sum")%></th>
            <th><%= Model.SearchResults.Criteria.Header("Дата посл. прихода", "date")%></th>
        </tr>
        <% foreach (ProductListAdminItem product in Model.SearchResults.Results)
           {%>
          <tr>
            <td><%= Html.ProductImage(product.Product) %></td>
            <td><a href="/Product/Details/<%= product.Product.Id %>"><%= product.Product.Name %></a></td>
            <td><%= product.Product.SKU %></td>
            <td><%= product.Product.Category.Name %></td>
            <td><%= product.Quantity %></td>
            <td><%= product.Date %></td>
          </tr>
        <%} %>
        
    </table>
    <%= Model.SearchResults.Criteria.Pages(Model.SearchResults.PageCount) %>
    <%} else {%>
        Нет товаров
    <%} %>
    <script type="text/javascript" language="javascript">
        $(document).ready(function() {
            $("#btn-filter").click(function() {
                if ($("#cat-select option:selected").val() != -1)
                    document.location.href = $("#cat-select option:selected").val();
                else
                    document.location.href = "/Admin/ListProducts/";
            });
        })
        
    </script>
</asp:Content>
