<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="elfam.web.Models" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Заказ готов к самовывозу - Elfam.ru</title>
</head>
<body>
 <% Order order = (Order) Model; %>
    <p>
        Здравствуйте, <%= order.User.Contact.Name %>!</p>
    <p>Рады сообщить вам, что ваш заказ в интернет-магазине elfam.ru собран и готов к самовывозу.

    <p>
        Заказы выдаются на станции метро Тургеневская, время обговаривается по телефону.</p>
    <p>
        Встреча на других станциях - по договоренности.</p>
    <p>
        После получения этого письма просьба позвонить нам по номеру 8-916-302-41-52 для 
        назначения встречи.</p>

    <p><a href="http://elfam.ru/Article/Details/11">Схема проезда</a></p>


    <p>Пожалуйста, берите с собой мелкие деньги!</p>
    <p>
        Номер вашего заказа <%= order.Uid %>  
        <% Html.RenderPartial("OrderLinesTable", Model); %>
        </p>
    <p>

    <p>
        Если у вас возникли вопросы, пишите на 
        <a href="mailto:admin@elfam.ru">admin@elfam.ru</a></p>
    <p>
                Наш телефон 8 (916) 302-41-52</p>
    <p>
        _____________________________</p>
    <p>
        Спасибо        что выбрали нас!</p>
    <p>
        Администрация elfam.ru</p>
</body>
</html>
