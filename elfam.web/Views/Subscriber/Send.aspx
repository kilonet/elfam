<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Отправка спама
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("TinyMceDeclaration"); %>
    
    <h2>Отправка спама</h2>
    <form action="/Subscriber/Send/" method="post">
    <div class="input-fields">
    <label for="Subject">Тема:</label><br />
    <input type="text" name="Subject" id="Subject"/><br />
    
    <label for="Text">Текст:</label><br />
    <%= Html.TextArea("Text", "", 20, 50, null) %>
    </div>
    <input type="submit" value="отправить"/>
    </form>
</asp:Content>
