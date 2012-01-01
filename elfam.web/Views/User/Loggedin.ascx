<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<elfam.web.Models.User>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<h2><%= Model.Contact.Name + " " + Model.Contact.Surname %></h2>
<table cellpadding="0" cellspacing="0" style="font-size:11px;">
<tr> <td colspan="2"> Сумма ваших заказов: </td> </tr>
<tr>
    <td style="width: <%= Model.GreenLength() %>px; height: 5px; background-color: #7DFF56; text-align:right;"><%= Model.Summ().ToCurrencyString() %></td>
    <td style="width: <%= Model.WhiteLength() %>px;"></td>
</tr>
<tr>
    <td colspan="2" align="center">
    <% if (Model.LeftToDiscount() > 0) {%>
    До постоянной скидки вам осталось <%= Model.LeftToDiscount().ToCurrencyString() %>
    <%} else {%>
    Поздравляем! Ваша скидка 10%!
    <%} %>
    </td>
</tr>
</table>
<a href="/User/MyOrders/">Мои заказы</a><br />
<a href="/User/MyInfo/">Мои данные</a><br />
<a href="/User/ChangePassword/">Смена пароля</a><br />
<% if (Model.IsAdmin) {%>
<a href="/Order/List/">Все заказы</a><br />
<a href="/User/List/">Все пользователи</a><br />
<a href="/Subscriber/List/">Подписчики</a> | <a href="/Subscriber/Send/">отправить спам</a><br />
Категории: <a href="/Category/List/">список</a> | <a href="/Category/Create/">добавить</a><br />
Товары: <a href="/Admin/ListProducts/">список</a> | <a href="/Product/Create/">добавить</a> | <a href="/Product/Report/">отчёт</a>  | <a href="/Question/List/"><% Html.RenderAction("RenderQuestionsLabel", "Question"); %></a> <br />
Приходы: <a href="/Income/List/">список</a> | <a href="/Income/Add/">добавить</a><br />
Расходы: <a href="/Outcome/List/">список</a><br />
<a href="/Setup/">Настройки</a><br />
<a href="/Article/">Статьи</a> | <a href="/Article/Create/">добавить</a><br />
<% } %>
<a href="/User/Logout/">Выход</a><br />

