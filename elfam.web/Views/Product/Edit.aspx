<%@ Page ValidateRequest="false"
Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.ViewModels.ProductViewModel>" %>
<%@ Import Namespace="elfam.web.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	- Редактирование - <%= Model.Name %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.RenderPartial("TinyMceDeclaration"); %>
    
    <h2><%= Model.Name %></h2>

    <form action="/Product/Edit/" method="post" enctype="multipart/form-data">
        <%= Html.ValidationSummary(true) %>
        <%= Html.HiddenFor(model => model.Id) %>
        
        
        Название<br/>
        <%= Html.TextBoxFor(model => model.Name) %>
        <%= Html.ValidationMessageFor(model => model.Name) %><br/>
        
        <%= Html.LabelFor(x => x.SKU) %><br/>
        <%= Html.TextBoxFor(x => x.SKU) %>
        <%= Html.ValidationMessageFor(x => x.SKU) %><br/>
        
        <%= Html.LabelFor(x => x.IsVisible) %>
        <%= Html.CheckBoxFor(x => x.IsVisible) %><br/>
        
        <%= Html.LabelFor(x => x.IsNew) %>
        <%= Html.CheckBoxFor(x => x.IsNew) %><br/>
      
        <%= Html.LabelFor(x => x.Size) %><br/>
        <%= Html.TextBoxFor(x => x.Size) %>
        <%= Html.ValidationMessageFor(x => x.Size) %><br/>
      
        <%= Html.LabelFor(x => x.Color) %><br/>
        <%= Html.TextBoxFor(x => x.Color) %>
        <%= Html.ValidationMessageFor(x => x.Color) %><br/>
      
        <%= Html.LabelFor(x => x.Weight) %><br/>
        <%= Html.TextBoxFor(x => x.Weight) %>
        <%= Html.ValidationMessageFor(x => x.Weight) %><br/>
      
        <%= Html.LabelFor(x => x.Country) %><br/>
        <%= Html.TextBoxFor(x => x.Country) %>
        <%= Html.ValidationMessageFor(x => x.Country) %><br/>
        
        Категория<br/>
        <%= Html.DropDownList("CategoryId", ViewData.Categories(Model.CategoryId)) %>
        <%= Html.ValidationMessageFor(model => model.CategoryId) %><br/>
        
        Цена<br/>
        <%= Html.TextBox("Price", Model.Price.ToString("G0")) %>
        <%= Html.ValidationMessageFor(model => model.Price) %><br/>
        
        Краткое описание<br/>
        <%= Html.TextAreaFor(model => model.ShortDescription, 10, 50, null)%>
        <%= Html.ValidationMessageFor(model => model.ShortDescription)%><br/>
        
        Описание<br/>
        <%= Html.TextAreaFor(model => model.Description, 10, 50, null) %>
        <%= Html.ValidationMessageFor(model => model.Description) %><br/>
        
        <input type="file" id="fileUpload[0]" name="fileUpload1"/><br/>
        <input type="file" id="fileUpload[1]" name="fileUpload2"/><br/>
        <input type="file" id="fileUpload[2]" name="fileUpload3"/><br/>
        
        <input type="submit" value="Save" />
</form>

    <% Html.RenderAction("SelectProductsWidget", "Product", new { productId = Model.Id }); %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>
    
    <% Html.RenderAction("ProductImages", new { productId = Model.Id }); %>
    

</asp:Content>

