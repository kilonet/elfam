<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<script type="text/javascript" language="javascript">
    var products;
    var recomended = new Array();
    $(document).ready(function() {

        $.getJSON('/Product/GetProductsJson/?productId=<%= ViewData["productId"] %>', function(data) {
            products = data;
            $.each(products, function(index, value) {
                var checked = value.IsRecomended ? 'checked' : '';
                
                $('#products').prepend('<div id="prod' + value.Id + '"><input class="recChk" value=' + value.Id + ' type="checkbox" ' + checked + '/> <span class="prod" id=' + value.Id + '>' + value.Name + '</span><br/></div>')
            })

            $('.recChk').change(function() {
                if ($(this).is(':checked')) {
                    recomended.push($(this).val());
                } else {
                    for (var i = 0; i < recomended.length; i++) {
                        if (recomended[i] == $(this).val()) {
                            recomended.splice(i, 1);
                            break;
                        };
                    };
                }
            });

        });



        $('#submitReccomended').click(function() {
            $.post('/Product/UpdateRecomended/', { 
                ids: recomended,
                productId: <%= ViewData["productId"] %> 
                },
            function(){
                $.gritter.add({
                        title: 'Сообщение',
                        text: 'Список рекомендуемых товаров обновлен',
                        time: 2000
                    });
            })
        });

        $('#search1').keyup(function() {
            // hide all
            for (var i = 0; i < products.length; i++) {
                $('#prod' + products[i].Id).hide();
            }
            
            for (var prod_id = 0; prod_id < products.length; prod_id++) {
                var checked = '';
                var value = products[prod_id];
                if (value.Name.toLowerCase().indexOf($('#search1').val().toLowerCase()) != -1) {

                    for (var i = 0; i < recomended.length; i++) {
                        if (recomended[i] == value.Id) {
                            checked = 'checked';
                            break;
                        };
                    };
                    $('#prod' + products[prod_id].Id).show();
                    //$('#products').prepend('<input class="recChk" value=' + value.Id + ' ' + checked + ' type="checkbox"/> <span class="prod" id=' + value.Id + '>' + value.Name + '</span><br/>')
                }
            }
            $.each(products, function(index, value) {

            })
        });
    })
</script>
<h2>Посмотрите также:</h2>
отметить галочками товары, нажать "Применить"<br/>
Фильтр: <input type='text' id='search1'/><br />
<div id='products'></div>
<input type='button' id='submitReccomended' value='Применить'/>

