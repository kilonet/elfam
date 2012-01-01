<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form action="/User/Login/" method="post">

    <table>
        <tr>
            <td>Email</td>
            <td><%= Html.TextBox("email") %></td>
        </tr>
        <tr>
            <td>Пароль</td>
            <td><%= Html.Password("password") %></td>
        </tr>
    </table>
    <%= Html.ValidationSummary() %>
    <input type="submit" value="Войти"/>
    
</form>

</asp:Content>
