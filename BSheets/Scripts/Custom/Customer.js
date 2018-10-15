var email_str = '';
var email_arr = Array();
var email_obj = [];

function output() {
    email_str = $("#eaddresses").val();
    email_obj = [];
    email_arr = email_str.split(/[,\n]/).filter(str => str != "");

    email_arr.forEach(function (address, index) {
        var valid_arr = address.match(/\w+@\w+\.\w+/);
        if (valid_arr == null) {
            alert("Invalid Email Address!");
            return false;
        }
        else if (address.length > 0) {
            email_obj.push({
                Address: address.trim()
            });
            return true;
        }
    });

    json_obj = {
        Company_Id: $("#cid").val(),
        Customer_Name: $("#cname").val(),
        Customer_Company: $("#company").val(),
        Phones: {
            Primary: $("#pphone").val(),
            Alternate: $("#aphone").val(),
            Fax: $("#fax").val()
        },
        Emails: email_obj,
        Website: $("#website").val(),
        Terms: $("#terms").val(),
        Locations: {
            Billing: $("#baddress").val(),
            Shipping: $("#saddress").val(),
        },
        Preferences: {
            Payment: $("#ppayment").val(),
            Delivery: $("#pdelivery").val()
        },
        Exemptions: $("#exemptions").val()
    };
    $("#J_Obj").val(JSON.stringify(json_obj));
    //$("#content").select();
}

$(function () {
    $("#Add").click(function (e) {
        e.preventDefault();
        if ($("#pphone").val().length > 0 && $("#pphone").val().length < 10) {
            alert("Primary Phone is too short!");
            return false;
        }
        if ($("#aphone").val().length > 0 && $("#aphone").val().length < 10) {
            alert("Alternate Phone is too short!");
            return false;
        }

        //var data = $("#customer_form").serialize();

        $.ajax({
            type: "post",
            url: "",
            data: "",
            success: function () {
                output();
            }
        });
    });
});