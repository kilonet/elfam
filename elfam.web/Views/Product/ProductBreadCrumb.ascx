<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<elfam.web.ViewModels.ProductBreadCrumbViewModel>>" %>
<%@ Import Namespace="elfam.web.ViewModels" %>

<% for (int i = 0; i < Model.Count; i++) {%>
<% ProductBreadCrumbViewModel category = Model[i]; %>
<a href="/Product/List/?categoryId=<%= category.Id %>"><%= category.Name %></a> <%= i == Model.Count-1 ? "" : " > "%> 
<% } %>