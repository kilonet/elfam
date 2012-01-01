<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<elfam.web.Models.User>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
        
        <div class="display-label">Email</div>
        <div class="display-field"><%= Html.Encode(Model.Email) %></div>
        
        <div class="display-label">Имя</div>
        <div class="display-field"><%= Html.Encode(Model.Contact.FullName)%></div>
        
        <div class="display-label">Подписан на новости</div>
        <div class="display-field"><%= Html.Encode(Model.IsSignedForNews.ToYesNo()) %></div>
        
        <div class="display-label">Скидка</div>
        <div class="display-field">
            <input type="text" value="<%= Html.Encode(Model.Discount) %>" id="input-discount"/>
            <span id="input-discount-val-message" class="field-validation-error"></span>
            <input type="button" value="Обновить" id="btn-discount"/>
        </div>
        
        <div class="display-label">Пользователь может логиниться</div>
        <div class="display-field"><input type="checkbox" id="canLogin" checked="<%= Model.CanLogin ? "checked" : "" %>" /></div>
        
        <div class="display-label">Админ</div>
        <div class="display-field"><%= Html.Encode(Model.IsAdmin.ToYesNo()) %></div>
        
        <div class="display-label">Адрес</div>
        <div class="display-field"><%= Html.Encode(Model.Contact.Address()) %></div>
        
        <div class="display-label">Телефон</div>
        <div class="display-field"><%= Html.Encode(Model.Contact.Phone)%></div>
        
        <input type="hidden" id="userId" value="<%= Model.Id %>">
        <script type="text/javascript" language="javascript">
            $("#btn-discount").click(function() {
                $.post("/User/Discount/", {
                    discount: $("#input-discount").val(), userId: $("#userId").val()
                },
                    function(errors) { handleErrors(["input-discount"], errors, "Спасибо", "Скидка установлена") })
            })

            $("#canLogin").change(function() {
                $.post("/User/CanLogin/", {
                    canLogin: $("#canLogin").is(':checked'), id: <%= Model.Id %>
                }, function(errors) {  })
            })
        </script>
 


