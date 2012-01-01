<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.ViewModels.ProductViewModel>" %>
<%@ Import Namespace="elfam.web.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.RenderPartial("TinyMceDeclaration"); %>

<form action="/Product/Create/" method="post" enctype="multipart/form-data">

    Название<br/>
    <%= Html.TextBox("Name", Model.Name) %>
    <%= Html.ValidationMessage("Name") %><br/>
    
    <%= Html.LabelFor(x => x.IsVisible) %><br/>
    <%= Html.CheckBoxFor(x => x.IsVisible) %><br />
    
    <%= Html.LabelFor(x => x.IsNew) %><br/>
    <%= Html.CheckBoxFor(x => x.IsNew) %><br />
    
    <%= Html.LabelFor(x => x.SKU) %><br/>
    <%= Html.TextBoxFor(x => x.SKU) %>
    <%= Html.ValidationMessageFor(x => x.SKU) %><br/>
  
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
    <%= Html.ValidationMessage("CategoryId")%><br/>
    
    Цена<br/>
    <%= Html.TextBox("Price", Model.Price) %>
    <%= Html.ValidationMessage("Price") %><br/>
    
    Описание<br/>
    <%= Html.TextAreaFor(model => model.Description, 10, 50, null)%>
    <%= Html.ValidationMessage("Description") %><br/>
    
    Краткое описание<br/>
    <%= Html.TextAreaFor(model => model.ShortDescription, 10, 50, null)%>
    <%= Html.ValidationMessageFor(model => model.ShortDescription) %><br/>
    
    <input type="file" id="fileUpload[0]" name="fileUpload1"/><br/>
    <input type="file" id="fileUpload[1]" name="fileUpload2"/><br/>
    <input type="file" id="fileUpload[2]" name="fileUpload3"/><br/>
    <input type="file" id="fileUpload[4]" name="fileUpload4"/><br/>
    <input type="file" id="fileUpload[5]" name="fileUpload5"/><br/>
    
    <input type="submit" value="Создать"/>
    
    
        
        
        
    
    
    </form>

</asp:Content>

