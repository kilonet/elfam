<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.Models.Order>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Models" %>
<%@ Import Namespace="elfam.web.ViewModels.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	- Редактирование информации о заказе
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Редактирование информации о заказе</h2>
    
        <div class="input-fields">
    <form action="/Order/Edit/" method="post">
    <input type="hidden" name="uid" value="<%= Model.Uid %>"/>
    Способ доставки<br />
    <%= Html.ValidationMessage("DeliverType")%><br />
    <select name="DeliverType" id="deliver">
        <% foreach (DeliverType deliver in Enum.GetValues(typeof(DeliverType))) {%>
            <option  <%= Model.DeliverType.Equals(deliver) ? "selected" : "" %> value="<%= (int)deliver %>"><%= deliver.Description(deliver)%> </option>
        <% } %>
    </select><br />        
        
    Способ оплаты<br />
    <select name="PaymentType">
        <% foreach (PaymentType payment in Enum.GetValues(typeof(PaymentType))) {%>
            <option value="<%= (int)payment %>"><%= payment.Description(payment)%> </option>
        <% } %>
    </select><br />
    <% var contactViewModel = ContactViewModel.From(Model.ShippingDetails); %>
    <%= Html.EditorFor(x => contactViewModel, "ContactEditor") %>
    
    <input type="submit" value="Обновить данные о заказе"/>
    </form>
    <form action="/Order/RevertUser/" method="post">
        <input type="hidden" name="uid" value="<%= Model.Uid %>"/>
        <input type="submit" value="Удалить заказ"/>
    </form>
    </div>

</asp:Content>
