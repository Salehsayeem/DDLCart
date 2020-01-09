
function getValue() {
    var myVal = $("#Items").val();
    $("#Price").val(myVal);
}
function init() {
    // Clear forms here
    document.getElementById("Items").value = "";
    document.getElementById("Price").value = "";
    document.getElementById("Quantity").value = "";
}

$(document).ready(function () {
    $('#ItemFrom #Price').prop('readonly', true);
    //For price dropdown

    $.ajax({
        type: "POST",
        url: "/Item/GetPriceByName",
        data: "{}",
        success: function (data) {
            var s = '<option value="0">Select </option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].Price + '">' + data[i].Name + '</option>';
                
            }

            $("#Items").html(s);
            
        }
    });

    $("#addToCart").click(function () {
        //For Table
        
        var quantity = Number($('#Quantity').val());
        var name = $('#Items option:selected').text();
        var price = $('#Price').val();
        var subTotal = parseInt(quantity, 10) * parseFloat(price);
        var totalOrder =0;
        totalOrder += parseInt(subTotal);
        for (var i = 0; i <subTotal.length; i++) {
            if (isNaN(subTotal)) {
                totalOrder += parseInt(subTotal[i]);
            }
        }

        
        if (quantity < 1 || quantity != /^[0-9]+$/) {
            $("#messageLabel").text("Please enter Quantity");

        }
        else {
            $("#messageLabel").text("");

        }
        
        if (name == null || name == 0 || name == "Select") {
            $("#messageLabel1").text("Name is not valid");
        }
        
        if ((quantity!=0 && name!=0 && price !=0)) {     
            
            var row = '<tr><td> ' + name + ' </td> <td> ' + price + ' </td> <td>' + quantity + ' </td> <td>' + subTotal + '</td> </tr>'
            $('#OrderData  tbody').append(row);

            
        }
        $('#OrderData #TotalOrder').html(totalOrder);
        
        init();


        //

    });
    
   
    
});

