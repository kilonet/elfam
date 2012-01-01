<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.ViewModels.MyOrdersViewModel>" %>
<%@ Import Namespace="elfam.web.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Мои заказы
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<link href="<%= Url.Content("~/Content/ui-lightness/jquery-ui-1.8.7.custom.css") %>" rel="stylesheet" type="text/css" />
    <h2>Мои заказы</h2>
    
    <% if (Model.Orders.Count > 0) {%>
    
    <table class="box-table-a">
        <tr>
            <th></th>
            <th>Дата</th>
            <th>Сумма</th>
            <th>Статус</th>
        </tr>

    <% foreach (var item in Model.Orders)
       { %>
    
        <tr>
            <td><a href="/Order/DetailsUser/<%= item.Uid %>">смотреть</a> | <a href="/Order/Edit/<%= item.Uid %>">редактировать</a> | <a onclick="confirmCancel(<%= item.Uid %>)"  href="#">отменить</a></td>
            <td><%= item.Date.ToString("d")%></td>
            <td><%= item.Total().ToString("C0")%></td>
            <td><span id="cancel<%= item.Uid %>"><%= item.Status.Description(item.Status)%></span></td>
        </tr>
    
    <% } %>

    </table>
    
    <%} else {%>
        Нет заказов
    <%} %>
    <div style="display: none;" id="confirm">
    Отменить заказ?
    </div>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.7/jquery-ui.min.js"></script>
    <script type="text/javascript" language="javascript">
        
        
            function confirmCancel(uid) {
                $("#confirm").dialog({
                    resizable: false,
                    height: 140,
                    modal: true,
                    buttons: {
                        "Отменить": function() {
                            
                            $.post("/Order/Cancel/", { "uid": uid }, function() {
                                $("#cancel" + uid).html("Отменен");
                            })
                            $(this).dialog("close");

                        },
                        "Не отменять": function() {
                            $(this).dialog("close");
                        }
                    }
                });

            }
        
    </script>
    
</asp:Content>
