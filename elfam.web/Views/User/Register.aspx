<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.ViewModels.UserViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Регистрация</h2>
<div class="input-fields">
 <form action="/User/Register" method="post">
    
            <%= Html.LabelFor(m => m.Email) %><br />
            <%= Html.ValidationMessageFor(m => m.Email) %><br />
            <%= Html.TextBoxFor(m => m.Email) %><br />
                
            <%= Html.LabelFor(m => m.Password) %><br />
            <%= Html.ValidationMessageFor(m => m.Password) %><br />
            <%= Html.PasswordFor(m => m.Password) %>    <br />
            
            <%= Html.LabelFor(m => m.ConfirmPassword) %><br />
            <%= Html.ValidationMessageFor(m => m.ConfirmPassword)%><br />
            <%= Html.PasswordFor(m => m.ConfirmPassword)%>    <br />
            
            <%= Html.EditorFor(m => m.Contact, "ContactEditor") %>
            
            <%= Html.LabelFor(m => m.IsSignForNews) %><br />
            <%= Html.CheckBoxFor(m => m.IsSignForNews)%><br />
            
           
                <input type="submit" value="Зарегистрироваться" />
                </form>
</div>          

    
        
    

</asp:Content>

