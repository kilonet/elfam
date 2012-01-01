<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="elfam.web.Models" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Новый заказ - Elfam.ru</title>
</head>
<body>
    <% Order order = (Order) Model; %>
    <p>Здравствуй, Света!</p>
    <p>тебе заказ в интернет-магазине elfam.ru.</p>
    <p>Это письмо отправлено автоматически</p>
    <p>Номер заказа <%= order.Uid %>  
        <% Html.RenderPartial("OrderLinesTable", Model); %>
    </p>
    <p>Адрес доставки:  <%= order.ShippingDetails.Address() %> </p>
    <p>Телефон:  <%= order.ShippingDetails.Phone %> </p>
    <p>Email:   <a href="mailto:<%= order.User.Email %>"><%= order.User.Email %></a> </p>
    <p>Имя:  <%= order.ShippingDetails.FullName %> </p>
    <p>Комментарий:  <%= order.Comment %> </p>
    <p> <a href="http://elfam.ru/Orders/Details/<%= order.Uid %>">ссылка на заказ</a></p>
    
</body>
</html>
