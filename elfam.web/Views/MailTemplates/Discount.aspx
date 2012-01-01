<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="elfam.web.Models" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    
</head>
<body>
    <% User user = (User) Model; %>
    <p>
        Здравствуйте, <%= user.Contact.Name %>!</p>
<p>Вас приветствует администрация магазина Elfam.ru</p>
<p>Рады сообщить вам, что теперь вы являетесь обладателем постоянной скидки в 10%, которая распространяется на все без исключения ваши заказы.</p>
<p>Эта скидка суммируется с прочими скидками нашего магазина.</p>


<p>Если у вас возникли вопросы, пишите на admin@elfam.ru<br/>
Наш телефон +7 (916) 302-41-52</p>
_____________________________
<p>Спасибо, что выбрали нас!<br />
Администрация elfam.ru</p>

</body>
</html>
