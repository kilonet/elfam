<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.Models.Order>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Инофрмация о заказе
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Информация о заказе</h2>
        Способ оплаты: <%= Model.PaymentType.Description(Model.PaymentType) %><br />
        Способ доставки: <%= Model.DeliverType.Description(Model.DeliverType) %><br />
        Адрес доставки: <%= Model.ShippingDetails.Address() %><br />
        Статус: <%= Model.Status.Description(Model.Status) %> (<a id="bill_link" href="#">квитанция для оплаты</a>) <br />
        Комментарий: <%= Model.Comment %><br />
        
        <% Html.RenderPartial("OrderDetails", Model); %>
        
       
    <script type="text/javascript" language="javascript">

        $(document).ready(function() {
            $("#bill_link").click(function() {
                window.open("/Order/Bill/<%= Model.Uid %>", "bill", "menubar=no,location=yes,resizable=yes,scrollbars=yes,status=yes,width=700,height=600");
            })
        })
    
    </script>
</asp:Content>
