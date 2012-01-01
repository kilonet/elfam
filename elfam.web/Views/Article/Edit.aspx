<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.Models.Article>" %>
<%@ Import Namespace="elfam.web.Extensions" %>
<%@ Import Namespace="elfam.web.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	- Редактирование статьи
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.RenderPartial("TinyMceDeclaration"); %> 
    <h2>Редактирование статьи</h2>
    <form action="/Article/Edit" method="post">
    <%= Html.ValidationSummary() %>
    
    <%= Html.HiddenFor(x => x.Id) %>
    <div class="input-fields">
    <%= Html.LabelFor(x => x.Title) %><br />
    <%= Html.ValidationMessageFor(x => x.Title) %><br />
    <%= Html.TextBoxFor(x => x.Title) %><br />
    
    <%= Html.LabelFor(x => x.Text) %><br />
    <%= Html.TextAreaFor(model => model.Text, 50, 70, null) %><br />
    <%= Html.ValidationMessageFor(x => x.Text)%><br/> 
    
    <%= Html.LabelFor(x => x.ManuallySetLastUpdated) %>(например 31-12-1999 или оставить пустой)<br />
    <%= Html.TextBoxFor(model => model.ManuallySetLastUpdated)%><br />
    <%= Html.ValidationMessageFor(x => x.Text)%><br/>
    
        
    <%= Html.LabelFor(x => x.Placement) %><br/>
    <select name="Placement">
        <% foreach (ArticlePlacement placement in Enum.GetValues(typeof(ArticlePlacement))) {%>
            <option  <%= Model.Placement.Equals(placement) ? "selected" : "" %> value="<%= (int)placement %>"><%= placement.Description(placement)%> </option>
        <% } %>
    </select><br />
    
    <%= Html.LabelFor(x => x.Index) %><br/>
    <%= Html.ValidationMessageFor(x => x.Index)%><br/>
    <%= Html.TextBoxFor(x => x.Index) %><br/>
    
    </div>
    <input type="submit" value="Создать"/>
    </form>
    
    <form method="post" action="/Article/Delete/" name="deleteForm">
    <%= Html.HiddenFor(x => x.Id) %>
    <input type="button" value="Удалить" id="btnDelete"/>
    </form>
    
    <script>
        $(function() {
            $('#btnDelete').click(function() {
                if (confirm('Точно удалить?')) {
                    document.forms['deleteForm'].submit();
                }

            })
        })
    </script>

</asp:Content>
