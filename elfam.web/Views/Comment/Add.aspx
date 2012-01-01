<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="elfam.web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	- Добавить отзыв
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Добавить отзыв</h2>
    Сюда вы можете загрузить свою фотографию или фотографию изделия, которое у вас получилось из наших материалов<br /><br />
    <div class="input-fields">
    <form action="/Comment/Add/" method="post" enctype="multipart/form-data">
    
    
    <label for="fileUpload">Картинка</label><br />
    <input type="file" id="fileUpload" name="fileUpload"/><br /><br />
    
    <label for="text">Комментарий</label><br />
    <%= Html.ValidationMessage("text")%><br />
    <%= Html.TextArea("text", ViewData["text"] != null ? ViewData["text"].ToString() : "", 10, 50, null)%><br />
    
    <% if (UserContext.User() != null) {%>
    <input type="submit" value="Добавить комментарий"/><br /><br />
    <%} else {%> Чтобы оставить отзыв необходимо залогиниться <%} %>
    
    </form>
    </div>

</asp:Content>
