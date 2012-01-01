<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<elfam.web.ViewModels.CategoryViewModel>" MasterPageFile="~/Views/Shared/Interchange.Master" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.FilterAttributes" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent"></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
<% Html.RenderPartial("TinyMceDeclaration"); %>   
<form action="<%= Url.Action("Create") %>" method="post" enctype="multipart/form-data">
<div class="input-fields">
<%= Html.LabelFor(x => x.ParentId) %>
<%= Html.DropDownList("ParentId", ViewData.Categories(Model.ParentId))%><br />

<%= Html.LabelFor(x => x.Name) %><br />
<%= Html.ValidationMessage("Name") %><br />
<%= Html.TextBox("Name", Model.Name) %><br />


<%= Html.LabelFor(x => x.Description) %><br />
<%= Html.ValidationMessageFor(x => x.Description) %><br />
<%= Html.TextAreaFor(x => x.Description, 10, 50, null) %>

</div>

 <h3>Картинка</h3>
 <input type="file" id="fileUpload" name="fileUpload"/><br />
    

<input type="submit" value="Создать"/>
        
</form>    
</asp:Content>
