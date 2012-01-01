<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.ViewModels.Cart.EnterShippingDetailsViewModel>" %>
<%@ Import Namespace="elfam.web" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	 - Информация о доставке
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Заказанные товары:</h3>
    
    <table class="box-table-a" id="cart-table">
        <tr>
            <th>Название</th>
            <th>Цена</th>
            <th>Количество</th>            
            <th>Сумма</th>
        </tr>
        <% foreach (CartItem item in Model.Cart.Items) {%>
            
            <tr>
                <td><%= item.Product.Name %></td>
                <td><%= item.Product.Price.ToCurrencyString()%></td>
                <td><%= item.Quantity %></td>
                <td><%= item.Summ().ToCurrencyString() %></td>
            </tr>
        
        <%} %>
        
        <tr>
            
            <td colspan="3">Сумма:</td>
            <td><%= Model.Cart.Summ().ToCurrencyString() %></td>
        </tr>
        
        <tr>
            
            <td colspan="3">Сумма со скидкой <%= UserContext.Discount() %> + <%= Model.Cart.CurrentDiscount() %>%:</td>
            <td><%= Model.Cart.SummDiscount().ToCurrencyString() %></td>
        </tr>
        
    </table>
    <input type="hidden" id="cart-price" value="<%= Model.Cart.SummDiscount() %>"/>
    <a href="/Cart/">Изменить содержимое корзины</a>
    
    <h3>Информация о доставке</h3>
    
    <form action="/Cart/Send/" method="post">
    <div class="input-fields">

    Способ доставки<br />
    <%= Html.ValidationMessage("DeliverType")%><br />
    <select name="DeliverType" id="deliver">
        <% foreach (DeliverType deliver in Enum.GetValues(typeof(DeliverType))) {%>
            <option  <%= Model.DeliverType.Equals(deliver) ? "selected" : "" %> value="<%= (int)deliver %>"><%= deliver.Description(deliver)%> </option>
        <% } %>
    </select><br />        
        
    Способ оплаты<br />
    <%= Html.ValidationMessage("PaymentType")%><br />
    <select name="PaymentType" id='payment'>
        <% foreach (PaymentType payment in Enum.GetValues(typeof(PaymentType))) {%>
            <option value="<%= (int)payment %>"><%= payment.Description(payment)%> </option>
        <% } %>
    </select><br />
    
    <%= Html.EditorFor(x => x.Contact, "ContactEditor") %>
    
    <%= Html.LabelFor(model => model.Comment) %><br />
    <%= Html.TextAreaFor(model => model.Comment, 5, 45, null) %><br />
    <%= Html.ValidationMessageFor(model => model.Comment) %><br />
    
    <input type="submit" value="Отправить заказ"/>
    </div>
    </form>
    
        
    <script language="javascript" type="text/javascript">
        $('#payment').change(function(){
            payment_id = $("#payment").val();
            price = 0;
            if (payment_id == <%= (int)PaymentType.OnPost %>) {
                price = <%= Model.DeliverPrices.PostWhenReceived(Model.Cart.SummDiscount()) %>;
            } else {
                $("#deliver").change()
                return;
            }
            totalPrice = parseFloat($("#cart-price").val()) + price; 
            
            updatePrices(price, totalPrice)
        })
    
        $("#deliver").change(function() {
            payment_id = $("#payment").val();
            deliver_id = $("#deliver").val();
            if (deliver_id == <%= (int)DeliverType.NULL %>) return;
            price = 0;
            if (deliver_id == <%= (int)DeliverType.CourierMoscow %>) {
                price = <%= Model.DeliverPrices.CourierMoscow %>;
            } else if (deliver_id == <%= (int)DeliverType.CourierSubMoscow %>) {
                price = <%= Model.DeliverPrices.CourierSubMoscow %>;
            } else if (deliver_id == <%= (int)DeliverType.Post %>) {
                if (payment_id == <%= (int)PaymentType.OnPost %> ) {
                    $('#payment').change();
                    return;
                }
                price = <%= Model.DeliverPrices.Post %>
            }

            totalPrice = parseFloat($("#cart-price").val()) + price;

            updatePrices(price, totalPrice)
        });
        
        function updatePrices(price, totalPrice){
            if ($('#deliver-row').length) {
                $('#deliver-row').replaceWith('<tr id="deliver-row"><td colspan="3">Доставка:</td><td>' + price + 'р.</td></tr>');
            } else {
                $('#cart-table tr:last').after('<tr id="deliver-row"><td colspan="3">Доставка:</td><td>' + price + 'р.</td></tr>');
            }

            if ($('#total-row').length) {
                $('#total-row').replaceWith('<tr id="total-row"><td colspan="3">Итого:</td><td>' + totalPrice + 'р.</td></tr>');
            } else {
                $('#cart-table tr:last').after('<tr id="total-row"><td colspan="3">Итого:</td><td>' + totalPrice + 'р.</td></tr>');
            }
        }
    </script>
</asp:Content>

