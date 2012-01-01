<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.ViewModels.CategoryViewModel>" %>
<%@ Import Namespace="elfam.web.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Редактирование
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% Html.RenderPartial("TinyMceDeclaration"); %>  
    <h3>Редактирование категории "<%= Model.Name %>"</h3>

	<form action="/Category/Edit/" method="post" enctype="multipart/form-data">
	<div class="input-fields">
	<%= Html.HiddenFor(model => model.Id) %>
    
    <%= Html.LabelFor(model => model.Name) %><br />
    <%= Html.ValidationMessageFor(model => model.Name) %><br />
    <%= Html.TextBoxFor(model => model.Name) %><br />
	
				
	<%= Html.LabelFor(model => model.ParentId) %><br />
	<%= Html.ValidationMessageFor(model => model.ParentId) %><br />
	<%= Html.DropDownListFor(model => model.ParentId, ViewData.CategoriesExcluding(Model.ParentId.Value, Model.Id)) %><br />
	
	<%= Html.LabelFor(x => x.Description) %><br />
    <%= Html.ValidationMessageFor(x => x.Description) %><br />
    <%= Html.TextAreaFor(x => x.Description, 10, 50, null) %><br />
    
    <%= Html.ValidationMessageFor(x => x.IsVisible) %><br />
    <%= Html.LabelFor(x => x.IsVisible) %>
    <%= Html.CheckBoxFor(x => x.IsVisible) %>
				
    </div>
    <h3>Картинка</h3>
    <input type="file" id="fileUpload" name="fileUpload"/>
    <%= Html.CategoryImage(Model.Image) %>
	<input type="submit" value="Save" />
    </form>
    
    <form action="/Category/DeleteImage/" method="post">
        <input type="hidden" name="categoryId" value="<%= Model.Id %>"/>
        <input type="submit" value="удалить картинку"/>
    </form>


    

</asp:Content>

