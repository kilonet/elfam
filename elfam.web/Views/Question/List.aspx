<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<elfam.web.Models.Question>>" %>
<%@ Import Namespace="elfam.web.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Вопросы
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Вопросы</h2>
    
    <% foreach(var q in Model) {%>    
    <div class="question">
    <table>
        <tr>
        <td>
            <%= Html.ProductImage(q.Product) %>
        </td>
        <td>
        
        <span id="question<%= q.Id %>" <%= q.IsAnswered ? "" : "class='bold'"%>>
        Пользователь: <%= q.User != null ? q.User.Contact.FullName : "аноним" %><br />
        Товар: <%= q.Product.Name %><br />
        Email: <a href="mailto:<%= q.Email %>"><%= q.Email %></a><br />
        Вопрос: <%= q.Text %><br />
        Дата: <%= q.Date.ToShortDateString() %><br />
        <%= q.IsAnswered ? "" : "</b>"%>
        </span>
        </td></tr>
        <tr>
            <td colspan="2">
                <label for="subject<%= q.Id %>">Тема</label>
                <input type="text" id="subject<%= q.Id %>"/><br />
                <textarea id="text<%= q.Id %>" rows="8" cols="50"><%= q.DefaultText() %></textarea><br />
                <input type="button" value="ответить" onclick="sendAnswer(<%= q.Id %>)"/>
            </td>
        </tr>
    </table>
    
    </div>
    <%} %>
    <% if (Model.Count() == 0) {%>
        Вопросов нет.
    <%} %>
        <script type="text/javascript" language="javascript">

            function sendAnswer(id) {
                $.post("/Question/Answer/", { questionId: id,
                    text: $("#text" + id).val(), subject: $("#subject" + id).val()
                },
                    function() {
                        handleErrors([], [], "Ответ отправлен", "Ответ отправлен");
                        $("#question" + id).removeClass("bold");
                    })
            }
        
        </script>
</asp:Content>
