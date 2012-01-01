<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="elfam.web.Controllers" %>

    <script language="javascript" type="text/javascript">
        function login() {
            var url = document.location.href;
            document.getElementById("returnUrl").value = url;
            document.getElementById("loginForm").submit();
        }
    </script>

    <h3>���� �� ��������</h3>
    <form action="/User/Login/" method="post" id="loginForm">

    Email<br/>
    <%= Html.TextBox("email") %>
    <br />

    ������<br/>
    <%= Html.Password("password") %>
    <br />
        
    <%= TempData[UserController.LOGIN_ERROR] %>
    
    <input type="hidden" id="returnUrl" name="returnUrl"/>
    <input type="button" value="�����" onclick="login();"/>
    <%= Html.ActionLink("�����������", "Register") %> | <a href="/User/Recover/">������ ������?</a>
    
    </form>
