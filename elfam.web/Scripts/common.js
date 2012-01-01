function handleErrors(errorKeysList, errorList ,title, text) {
    $(errorKeysList).each(function(index, errorKey) {
        $("#" + errorKey).removeClass("input-validation-error");
        $("#" + errorKey + "-val-message").html("");
    });

    $(errorList).each(function(index, error) {
        $("#" + error.Key).addClass("input-validation-error");
        $("#" + error.Key + "-val-message").html(error.Value);
    });
    
    if (errorList.length == 0) {
        $.gritter.add({
            title: title,
            text: text,
            time: 2000
        });
    }
}


function flash(message) {
    $.gritter.add({
        title: 'elfam.ru',
        text: message,
        time: 2000
    });
}


function addToCart(productId) {
    var productName = $("#productName" + productId).val();
    var quantity = $("#quantity" + productId).val();
    $("#quantity" + productId).removeClass("input-validation-error");
    $("#quantity" + productId + "-val-message").html("");
    $.ajax({
        type: 'POST',
        url: '/Cart/Add/',
        data: { productId: productId, quantity: quantity },
        success: function(errors) {
            if (errors.length == 0) {
                $.gritter.add({
                    title: 'Товар добавлен в корзину',
                    text: productName + ' ' + quantity + ' шт.',
                    time: 2000
                });
                $('#cart-container').load('/Cart/CartWidget/')
            } else {
                $(errors).each(function(index, error) {
                    $("#" + error.Key + productId).addClass("input-validation-error");
                    $("#" + error.Key + +productId + "-val-message").html(error.Value);
            });
            }
        },
        error: function() {
            
        }
    });

}