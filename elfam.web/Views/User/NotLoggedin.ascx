<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="elfam.web.Controllers" %>

    <script language="javascript" type="text/javascript">
        function login() {
            var url = document.location.href;
            document.getElementById("returnUrl").value = url;
            document.getElementById("loginForm").submit();
        }
    </script>

    <h3>Вход не выполнен</h3>
    <form action="/User/Login/" method="post" id="loginForm">

    Email<br/>
    <%= Html.TextBox("email") %>
    <br />

    Пароль<br/>
    <%= Html.Password("password") %>
    <br />
        
    <%= TempData[UserController.LOGIN_ERROR] %>
    
    <input type="hidden" id="returnUrl" name="returnUrl"/>
    <input type="button" value="Войти" onclick="login();"/>
    <%= Html.ActionLink("Регистрация", "Register") %> | <a href="/User/Recover/">забыли пароль?</a>
    
    </form>
