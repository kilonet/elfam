<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.IList<elfam.web.Models.User>>" MasterPageFile="~/Views/Shared/Interchange.Master" %>
<%@ Import Namespace="elfam.web.Models" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent"></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">

<ul>
<% foreach (User user in Model) {%>

    <li><%= user.Email %></li>
  
<% } %>
</ul>


</asp:Content>
