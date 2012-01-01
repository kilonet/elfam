<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.Paging.SearchResults<elfam.web.Models.Article>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Новости
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


        <% foreach (var news in Model.Results) { %>
            <h3><%= news.Title %></h3>    
            <%= news.Text %><br /><small><em><%= news.LastUpdated.ToLongDateString() %></em></small><br /><br />
    
        <% } %>

                
        <%= Model.Criteria.Pages(Model.PageCount) %>

</asp:Content>
