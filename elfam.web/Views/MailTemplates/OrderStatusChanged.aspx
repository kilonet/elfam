<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="elfam.web.Models" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Уведомление - Elfam.ru</title>
</head>
<body>
    <div>
        <% Order order = (Order) Model; %>
        Уважаемый <%= order.User.Contact.FullName %>! <br />
        <%
            switch(order.Status)
            {
                case OrderStatus.Payed: %>
                    Спасибо за оплату Вашего заказа № <%= order.Uid %> от <%= order.Date.ToShortDateString() %>
                <% break;
                case OrderStatus.Sent: %>
                    Ваш заказ № <%= order.Uid %> от <%= order.Date.ToShortDateString() %> был отправлен по адресу <%= order.ShippingDetails.Address() %>
                <% break;
                case OrderStatus.WaitPayment: %>
                    Ваш заказ № <%= order.Uid %> от <%= order.Date.ToShortDateString() %> был зерезервирован и ожидает оплаты
                <% break;
                case OrderStatus.WaitPickup: %>
                    Ваш заказ № <%= order.Uid %> от <%= order.Date.ToShortDateString() %> был укомплектован и ожидает самовывоза    
                <% break;
            }   
        %>
    </div>
    Elaf.ru
</body>
</html>
