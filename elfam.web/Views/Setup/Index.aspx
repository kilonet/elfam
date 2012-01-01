<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.Models.DeliverPrices>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	- Настройки магазина 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Настройки магазина</h2>
    
    <div class="input-fields">
    
    <form action="/Setup/" method="post">
    
    
    
    Цена доставки курьером по Москве<br />
    <%= Html.ValidationMessage("CourierMoscow")%><br />
    <input type="text" name="CourierMoscow" value="<%= (int)Model.CourierMoscow %>"/><br/>
    
    Цена доставки курьером по Подмосковью<br />
    <%= Html.ValidationMessage("CourierSubMoscow")%><br />
    <input type="text" name="CourierSubMoscow" value="<%= (int)Model.CourierSubMoscow %>"/><br/>
    
    Цена доставки почтой<br />
    <%= Html.ValidationMessage("Post")%><br />
    <input type="text" name="Post" value="<%= (int)Model.Post %>"/><br/>
    
    Цена доставки самовывозом<br />
    <%= Html.ValidationMessage("Self")%><br />
    <input type="text" name="Self" value="<%= (int)Model.Self %>"/><br/>
    
    <input type="submit" value="Обновить"/>
    
    </form>
    
    </div>

</asp:Content>
