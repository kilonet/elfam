<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.ViewModels.ProductViewModel>" %>
<%@ Import Namespace="elfam.web" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Models" %>
<%@ Import Namespace="elfam.web.Utils" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	- <%= Model.Name %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

    <% Html.RenderPartial("ProductBreadCrumb", Model.ProductBreadCrumbViewModels); %>
    <table>
        <tr>
            <td>
                <table><tr>
                    <td colspan="2"><h2><%= Model.Name %></h2></td>
                </tr>
                <tr>
                <td>
                <% if (Model.IsAvailable){%>
                    <span class="price"><%= Model.Price.ToString("C0") %></span>
                <% } %>
                </td>
                <td width="100%">
                <% if (Model.IsAvailable){%>
                    <input type="hidden" id="productName<%= Model.Id %>" value="<%= Model.Name %>"/>
                    ���-��:<input type="text" class="quantity-input" value="1" id="quantity<%= Model.Id %>"/>
                    <span id="quantity<%= Model.Id %>-val-message" class="field-validation-error"></span><br />
                    <input type="button" value="� �������" onclick="addToCart(<%= Model.Id %>)"/>
                <% } %>
                </td>
                </tr>
                </table>
                
                <% if (!Model.IsAvailable) {%>
                    <span class="na">�������� ��� � �������</span>
                <%} %>
            </td>

        </tr>
        <tr><td colspan="2">
            <% if (Model.Images.Count > 0) {%>
            <% foreach (elfam.web.Models.Image image in Model.Images) {%>
                <a rel="lightbox" href="<%=ResolveClientUrl("~/Content/Uploads/") + image.Big%>">
                    <img  border="0" src="<%=ResolveClientUrl("~/Content/Uploads/") + image.Small%>"/>
                </a>
            <% }} %>
            
           
           
        </td></tr>
        <tr>
            <td colspan="2">
                �������: <%= Model.SKU %><br />
                <% if (!string.IsNullOrEmpty(Model.Size)) {%>
                ������: <%= Model.Size %><br />
                <%} %>
                
                <% if (!string.IsNullOrEmpty(Model.Color)) {%>
                ����: <%= Model.Color %><br />
                <%} %>
                
                <% if (!string.IsNullOrEmpty(Model.Weight)) {%>
                ���: <%= Model.Weight %><br />
                <%} %>
                
                <% if (!string.IsNullOrEmpty(Model.Country)) {%>
                ������: <%= Model.Country %><br />
                <%} %>
                
                <%= Model.Description %>
            </td>
        </tr>
    </table>
    
    <h3>������� ������ ��� �����</h3>
    <form action="/Question/Ask/" method="post">
    
    <%= Html.Hidden("ProductId", Model.Id) %>
        
    <div class="input-fields">
    <label for="Email">Email *</label><br />
    <span id="Email-val-message" class="field-validation-error"></span><br />
    <input type="text" name="Email" id="Email" value="<%= UserContext.User() != null ? UserContext.User().Email : "" %>"/><br />
    
    <label for="Text">������ *</label><br />
    <span id="Text-val-message" class="field-validation-error"></span><br />
    <textarea name="Text" id="Text" rows="10" cols="50"></textarea><br />
    
    <input type="button" id="submitQuestion" value="���������"/>
    
    </div>
    </form>
    <% if (Model.Recomended.Count > 0) {%>
    <h3>����������� ����� ����������:</h3>
    <table class="see-also">
        <tr>
    <% foreach (Product product in Model.Recomended){ %>
        <td align="center">
            <a href="/Product/Details/<%= product.Id %>"><%= Html.ProductImageNoLink(product) %><br />
            <%= product.Name %></a>       
        </td>
    <% } %>
        </tr>
    </table>
    <% } %>
    <p><%= Html.AdminActionLink("�������������", "Edit", new { id = Model.Id })%></p>
    <script type="text/javascript" language="javascript">

        $("#submitQuestion").click(function() {
            $.ajax({
                type: 'POST',
                url: '/Question/Ask/',
                data: { Email: $("#Email").val(), Text: $("#Text").val(), ProductId: $("#ProductId").val() },
                success: function(data) {
                    $("#Email").removeClass("input-validation-error");
                    $("#Text").removeClass("input-validation-error");
                    $("#Email-val-message").html("");
                    $("#Text-val-message").html("");
                    $.each(data, function(i) {
                        $("#" + data[i].Key).addClass("input-validation-error");
                        $("#" + data[i].Key + "-val-message").html(data[i].Value);
                    })
                    if (data.length == 0) {
                        $.gritter.add({
                            title: '��� ������ ���������',
                            text: '������� �� ������! ��� ������� �� email.',
                            time: 2000
                        });
                    }
                }
            });
        });
        
    </script>
</asp:Content>

