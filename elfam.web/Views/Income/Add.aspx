<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Interchange.Master" Inherits="System.Web.Mvc.ViewPage<elfam.web.ViewModels.IncomeViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Добавить приход
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <script language="javascript" type="text/javascript">
        var products = []

        $(function() {
            $('#ProductId > option').each(function(i, elem) {
                products.push({ id: $(elem).val(), name: $(elem).text() })
            })

            $('#productName').keyup(function() {
                 var select = document.getElementById('ProductId')
                $('#ProductId > option').remove()
                $(products).each(function(i, elem){
                if (elem.name.toLowerCase().search($('#productName').val().toLowerCase()) != -1 || $('#productName').val() == '') {
                    var option = document.createElement("option")
                    option.text = elem.name
                    option.value = elem.id
                        select.options.add(option)
                    }
                }) 
               
            })
        })
    </script>

    <h2>Добавить приход</h2>
    
    <form action="/Income/Add/" method="post">
        <div class="input-fields">
        <%= Html.LabelFor(x => x.ProductId) %><br />
        <%= Html.DropDownListFor(x => x.ProductId, Model.Products, new{size = 10}) %><br />
        <input id="productName" placeholder="вводи сюда часть названия товара и список сверху будет фильтроваться" size="80"/>
        <br />
        
        <%= Html.LabelFor(x => x.BuyPrice) %><br />
        <%= Html.ValidationMessageFor(x => x.BuyPrice) %><br />
        <%= Html.TextBoxFor(x => x.BuyPrice, Model.BuyPrice) %><br />
        
        
        <%= Html.LabelFor(x => x.Quantity) %><br />
        <%= Html.ValidationMessageFor(x => x.Quantity) %><br />
        <%= Html.TextBoxFor(x => x.Quantity, Model.Quantity) %><br />
        
        </div>
        <input type="submit" value="добавить"/>
    </form>

</asp:Content>
