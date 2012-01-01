<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	- Оформление заказа
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Оформление заказа</h2>
    Чтобы продолжить оформление заказ необходимо выполнить вход:<br />
    
    <form action="/Cart/LoginAndCheckout/" method="post">
    Email:<br />
    <input type="text" name="email"/>    <br />
    Пароль:<br />
    <input type="password" name="password"/> <br />
    <%= Html.ValidationSummary() %>
    <input type="submit" value="Войти"/>
    </form>
    
    <a href="/User/Register/">Пройти регистрацию</a>
</asp:Content>
