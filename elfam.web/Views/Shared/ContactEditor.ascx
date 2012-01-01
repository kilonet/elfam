<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<elfam.web.ViewModels.User.ContactViewModel>" %>

<%= Html.LabelFor(model => model.Name) %>
<%= Html.TextBoxFor(model => model.Name)%>
<%= Html.ValidationMessageFor(model => model.Name)%>

<%= Html.LabelFor(model => model.Surname) %>
<%= Html.TextBoxFor(model => model.Surname)%>
<%= Html.ValidationMessageFor(model => model.Surname)%>

<%= Html.LabelFor(model => model.Country) %>
<%= Html.TextBoxFor(model => model.Country) %>
<%= Html.ValidationMessageFor(model => model.Country) %>

<%= Html.LabelFor(model => model.Region) %>
<%= Html.TextBoxFor(model => model.Region) %>
<%= Html.ValidationMessageFor(model => model.Region) %>

<%= Html.LabelFor(model => model.City) %>
<%= Html.TextBoxFor(model => model.City) %>
<%= Html.ValidationMessageFor(model => model.City) %>

<%= Html.LabelFor(model => model.Street) %>
<%= Html.TextBoxFor(model => model.Street) %>
<%= Html.ValidationMessageFor(model => model.Street) %>

<%= Html.LabelFor(model => model.House) %>
<%= Html.TextBoxFor(model => model.House) %>
<%= Html.ValidationMessageFor(model => model.House) %>

<%= Html.LabelFor(model => model.Zip) %>
<%= Html.TextBoxFor(model => model.Zip) %>
<%= Html.ValidationMessageFor(model => model.Zip) %>

<%= Html.LabelFor(model => model.Room) %>
<%= Html.TextBoxFor(model => model.Room) %>
<%= Html.ValidationMessageFor(model => model.Room) %>

<%= Html.LabelFor(model => model.Phone) %>
<%= Html.TextBoxFor(model => model.Phone)%>
<%= Html.ValidationMessageFor(model => model.Phone)%>





