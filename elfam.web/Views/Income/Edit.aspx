<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.ViewModels.IncomeViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	 - Редактирование прихода
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Редактирование прихода</h2>
    
    <form action="/Income/Edit/" method="post">
        <div class="input-fields">
        
        <%= Html.HiddenFor(x => x.IncomeId) %>
        
        <%= Html.LabelFor(x => x.ProductId) %><br />
        <%= Html.DropDownListFor(x => x.ProductId, Model.Products) %><br />
        
        <%= Html.LabelFor(x => x.BuyPrice) %><br />
        <%= Html.ValidationMessageFor(x => x.BuyPrice) %><br />
        <%= Html.TextBoxFor(x => x.BuyPrice, Model.BuyPrice) %><br />
        
        
        <%= Html.LabelFor(x => x.Quantity) %><br />
        <%= Html.ValidationMessageFor(x => x.Quantity) %><br />
        <%= Html.TextBoxFor(x => x.Quantity, Model.Quantity) %><br />
        
        </div>
        <input type="submit" value="сохранить"/>
    </form>

</asp:Content>
