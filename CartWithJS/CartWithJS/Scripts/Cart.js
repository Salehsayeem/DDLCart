function getValue() {
    var myVal = $("#Name").val();
    $("#Price").val(myVal);
}
function QuantityValidation(quantity){
    var num = /^[0-9]+$/;
    if(quantity.value.match(num)){
        return true;
    }
    else{
        console.log(num,"Error");
        quantity.focus();
        return false;
    }
}
function formValidation() {
    var name = $('#Name option:selected').text();
    var quantity = Number($('#Quantity').val());
    var price = Number($('#Price').val());
    if(QuantityValidation(q)) {
        
    }
    return false;
}
$(document).ready(function () {
    $('#CartForm #Price').prop('readonly', true);
    //For price dropdown

    $.ajax({
        type: "POST",
        url: "/Cart/GetPriceByName",
        data: "{}",
        success: function (data) {
            var s = '<option value="0">Select </option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].Price + '">' + data[i].Name + '</option>';

            }

            $("#Name").html(s);

        }
    });
});