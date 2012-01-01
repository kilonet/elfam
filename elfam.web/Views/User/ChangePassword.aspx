<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
 	 - Смена пароля
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Смена пароля</h2>
    
    <div class="input-fields">
    
    <form action="/User/ChangePassword/" method="post">
        
        <label for="password">Старый пароль</label><br />
        <%= Html.ValidationMessage("password") %><br />
        <input type="password" id="password" name="password"/><br />        
        
        <label for="newPassword">Новый пароль</label><br />
        <%= Html.ValidationMessage("newPassword")%><br />
        <input type="password" id="newPassword" name="newPassword"/><br />        
        
        <label for="confirmNewPassword">Подтвердите новый пароль</label><br />
        <%= Html.ValidationMessage("confirmNewPassword")%><br />
        <input type="password" id="confirmNewPassword" name="confirmNewPassword"/><br />  
        
        <input type="submit" value="Сменить пароль"/>      
        
    </form>
    
    </div>
    

</asp:Content>
