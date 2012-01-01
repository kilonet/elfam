<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	 - Восстановление пароля
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Восстановление пароля</h2>
    
    <div class="input-fields">
    <form action="/User/Recover/" method="post">
    
    <label for="email">Введите ваш E-Mail:</label><br />
    <%= Html.ValidationMessage("email") %><br />
    <input type="text" id="email" name="email"/>
    
    <input type="submit" value="Восстановить пароль"/>
    
    </form>
    </div>

</asp:Content>
