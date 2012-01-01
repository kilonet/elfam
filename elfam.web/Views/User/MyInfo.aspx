<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.ViewModels.MyInfoViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Мои данные
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Мои данные</h2>
    
    <form action="/User/MyInfo/" method="post">
        <div class="input-fields">
            <%= Html.LabelFor(x => x.Email) %><br />
            <%= Html.ValidationMessageFor(x => x.Email) %><br />
            <%= Html.TextBoxFor(x => x.Email) %><br />
            
            <%= Html.EditorFor(x => x.Contact, "ContactEditor") %>
            
            <%= Html.LabelFor(m => m.IsSignForNews) %><br />
            <%= Html.CheckBoxFor(m => m.IsSignForNews)%><br />
        </div>
        <input type="submit" value="сохранить"/>
    </form>

</asp:Content>
