<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Свежие новости</h3>
    
     <% var article = (Article) ViewData["news"]; %>  
    <h3><%= article.Title %></h3>
    <%= article.Text %><small><em><%= article.LastUpdated.ToLongDateString() %></em></small>
    
    <%= ViewData["article"] %>
    
    <div class="example">
        <ul> 
        <% foreach (Category category in (IEnumerable<Category>)ViewData["categories"])
           {%>
                <li>
                        <a href="/Product/List/?categoryId=<%= category.Id %>">
                            <%= Html.CategoryImage(category.Image)%><br />
                            <%= category.Name%><br />
                        </a>
                </li>
        <% } %>
        </ul>
    </div>


</asp:Content>
