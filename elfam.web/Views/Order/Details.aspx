<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.Models.Order>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Информация о заказе <%= Model.Id %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Информация о заказе <%= Model.Uid %></h3>
    Заказ от пользователя <%= Model.User.Contact.FullName %> от <%= Model.Date %><br />
    Адрес: <%= Model.ShippingDetails.Address() %><br />
    Телефон: <%= Model.ShippingDetails.Phone %><br />
    Оплата: <%= Model.PaymentType.Description(Model.PaymentType) %><br />
    Доставка: <%= Model.DeliverType.Description(Model.DeliverType) %><br />   
    Комментарий: <%= Model.Comment %><br />   
    Статус: 
    <form action="/Order/Update/" method="post">
    <input type="hidden" name="orderId" value="<%= Model.Id %>"/>
    <select name="status">
        <% foreach (OrderStatus status in Enum.GetValues(typeof(OrderStatus))) {%>
        <% string selected = status == Model.Status ? "selected" : ""; %>
            <option <%= selected %> value="<%= (int)status %>"><%= status.Description(status) %> </option>
        <% } %>
    </select><input type="submit" value="Сохранить"/>
    </form><br />
    
    <% Html.RenderPartial("OrderDetails", Model); %>
    
    <p>
        <%= Html.ActionLink("Назад к списку", "List") %>
    </p>

</asp:Content>


