<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.ViewModels.Cart.ReviewCartViewModel>" %>
<%@ Import Namespace="elfam.web" %>
<%@ Import Namespace="elfam.web.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
 - Содержимое корзины
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" language="javascript">
        function removeFromCart(id) {
            document.getElementById("ProductId").value = id;
            document.forms['removeForm'].submit();
        }
    </script>

    <h2>Содержимое корзины</h2>
    
    <% if (Model.Cart.Items.Count > 0) {%>
    <% Html.EnableClientValidation(); %>
    
    <form method="post" name="cartForm">
    <table class="box-table-a">
        <tr>
            <th></th><th>Товар</th><th>Цена</th><th>Кол-во</th><th>Сумма</th><th></th>
        </tr>
    <% int i = 0; %>
    <%foreach (var item in Model.Cart.Items)
      { %>
        <tr>
            <td>
                <%= Html.ProductImage(item.Product) %>
            </td>
            <td>
                <%= item.Product.Name%>
                <%= Html.Hidden("CartLines[" + i + "].ProductId", item.Product.Id)%>
            </td>
            <td><%= item.Product.Price.ToString("C0")%></td>
            <td>
                <%= Html.TextBox("CartLines[" + i + "].Quantity", item.Quantity)%><br />
                <%= Html.ValidationMessage("CartLines[" + i + "].Quantity")%>
            </td>
            <td><%= item.Summ().ToString("C0")%></td>
            <td><input type="button" value="Удалить" onclick="removeFromCart(<%= item.Product.Id %>)"/></td>
        </tr>
    <% i++; %>
    <% } %>
        <tr>
            <td></td><td></td><td>Общая сумма</td><td><%= Model.Cart.Summ().ToCurrencyString()%></td><td></td><td></td>
        </tr>
        <tr>
        <td></td><td></td><td>Общая сумма со скидкой <%= UserContext.Discount() %> + <%= Model.Cart.CurrentDiscount() %>%</td><td><%= Model.Cart.SummDiscount().ToCurrencyString()%></td><td></td><td></td>
        </tr>
    </table>
    <%= Html.ValidationMessage("summ") %><div>
    <input type="button" value="Оформить заказ" id="sendOrder"/>
    <input type="button" value="Пересчитать цены" id="recalc"/></div>
    </form>
    <form id="removeForm" action="/Cart/Remove/" method="post">
        <input type="hidden" name="productId" id="ProductId"/>
    </form>
    <%} else{ %>
        В корзине пусто
    <% } %>
    
    <script type="text/javascript" language="javascript">
        $(document).ready(function() { 
            $("#sendOrder").click(function(){
               document.forms["cartForm"].action = "/Cart/Checkout";
               document.forms["cartForm"].submit();
            });
            $("#recalc").click(function(){
               document.forms["cartForm"].action = "/Cart/Recalc";
               document.forms["cartForm"].submit();
            });
        });
    </script>
    
</asp:Content>
