<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.Models.Article>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	- Редактирование статьи
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.RenderPartial("TinyMceDeclaration"); %> 
    <h2>Редактирование статьи</h2>
    <form action="/Article/Create" method="post">
    <%= Html.ValidationSummary() %>
    <div class="input-fields">
    <%= Html.LabelFor(x => x.Title) %><br />
    <%= Html.ValidationMessageFor(x => x.Title) %><br />
    <%= Html.TextBoxFor(x => x.Title) %><br />
    
    <%= Html.LabelFor(x => x.Text) %><br />
    <%= Html.ValidationMessageFor(x => x.Text)%><br/>
    <%= Html.TextAreaFor(model => model.Text, 100, 70, null) %><br />
    
    <%= Html.LabelFor(x => x.Placement) %><br/>
        <select name="Placement">
        <% foreach (ArticlePlacement placement in Enum.GetValues(typeof(ArticlePlacement))) {%>
            <option value="<%= (int)placement %>"><%= placement.Description(placement)%> </option>
        <% } %>
    </select><br />
    
    <%= Html.LabelFor(x => x.Index) %><br/>
    <%= Html.ValidationMessageFor(x => x.Index)%><br/>
    <%= Html.TextBoxFor(x => x.Index) %><br/>
    
    </div>
    <input type="submit" value="Создать"/>
    </form>
</asp:Content>
