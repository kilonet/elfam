<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="elfam.web.Models" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Заказ отправлен - Elfam.ru</title>
    
</head>
<body>
    <% Order order = (Order) Model; %>
    <p>
        Здравствуйте, <%= order.User.Contact.Name %>!</p>
    <p>
        Рады сообщить вам, что ваш заказ в интернет-магазине elfam.ru 
        собран и отправлен.</p>
    <p>
        Пожалуйста, сообщите нам, когда получите его по e-mail <a href="mailto:admin@elfam.ru">admin@elfam.ru</a> или по телефону 8(916)932-82-522</p>
    <p>
        Номер вашего заказа <%= order.Uid %>  
        <% Html.RenderPartial("OrderLinesTable", Model); %>
        </p>
    <p>
                Адрес доставки:  <%= order.ShippingDetails.Address() %> </p>
    <p>
        Если у вас возникли вопросы, пишите на 
        <a href="mailto:admin@elfam.ru">admin@elfam.ru</a></p>
    <p>
                Наш телефон +7 (916) 302-41-52</p>
    <p>
        _____________________________</p>
    <p>
        Спасибо        что выбрали нас!</p>
    <p>
        Администрация elfam.ru</p>
</body>
</html>
