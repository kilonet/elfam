<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<elfam.web.Models.User>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<h2><%= Model.Contact.Name + " " + Model.Contact.Surname %></h2>
<table cellpadding="0" cellspacing="0" style="font-size:11px;">
<tr> <td colspan="2"> ����� ����� �������: </td> </tr>
<tr>
    <td style="width: <%= Model.GreenLength() %>px; height: 5px; background-color: #7DFF56; text-align:right;"><%= Model.Summ().ToCurrencyString() %></td>
    <td style="width: <%= Model.WhiteLength() %>px;"></td>
</tr>
<tr>
    <td colspan="2" align="center">
    <% if (Model.LeftToDiscount() > 0) {%>
    �� ���������� ������ ��� �������� <%= Model.LeftToDiscount().ToCurrencyString() %>
    <%} else {%>
    �����������! ���� ������ 10%!
    <%} %>
    </td>
</tr>
</table>
<a href="/User/MyOrders/">��� ������</a><br />
<a href="/User/MyInfo/">��� ������</a><br />
<a href="/User/ChangePassword/">����� ������</a><br />
<% if (Model.IsAdmin) {%>
<a href="/Order/List/">��� ������</a><br />
<a href="/User/List/">��� ������������</a><br />
<a href="/Subscriber/List/">����������</a> | <a href="/Subscriber/Send/">��������� ����</a><br />
���������: <a href="/Category/List/">������</a> | <a href="/Category/Create/">��������</a><br />
������: <a href="/Admin/ListProducts/">������</a> | <a href="/Product/Create/">��������</a> | <a href="/Product/Report/">�����</a>  | <a href="/Question/List/"><% Html.RenderAction("RenderQuestionsLabel", "Question"); %></a> <br />
�������: <a href="/Income/List/">������</a> | <a href="/Income/Add/">��������</a><br />
�������: <a href="/Outcome/List/">������</a><br />
<a href="/Setup/">���������</a><br />
<a href="/Article/">������</a> | <a href="/Article/Create/">��������</a><br />
<% } %>
<a href="/User/Logout/">�����</a><br />

