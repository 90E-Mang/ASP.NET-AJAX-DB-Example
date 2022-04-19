$(document).ready(function () {
    loadData();
});

function loadData() {
    $.ajax(
        {
            url: "Home/List",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                console.log(result);

                let html = "";
                $.each(result, function (index,item) {
                    html += "<tr>";
                    html += "<td>" + item.EmployeeID + "</td>";
                    html += "<td>" + item.Name + "</td>";
                    html += "<td>" + item.Age + "</td>";
                    html += "<td>" + item.State + "</td>";
                    html += "<td>" + item.Country + "</td>";
                    html += "<td><a href=# onclick=''>EDIT</a></td>";
                    html += "</tr>";
                });
                $('.tbody').html(html);
            },
            error: function (errmsg) {
                alert(errmsg.responseText);
            }
        }
    );
}
function Add() {
    // 추가할 데이터 JSON으로 받아오기

    let empobj = {
        employeeid: $('#EmployeeID').val(),
        name: $('#Name').val(),
        age: $('#Age').val(),
        state: $('#State').val(),
        country: $('#Country').val()
    };
    $.ajax(
        {
            url: "Home/Add",
            data: JSON.stringify(empobj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
               // loadData(); // 비동기 조회 함수 호출
                console.log(result);
                $('#myModal').modal('hide');
            },
            error: function (errmsg) {
                alert(errmsg.responseText);
            }
        }
    );
}
function Update() {
    $.ajax();
}
function Delete(ID) {
    $.ajax();
}
function clearTextBox() {
    $('#EmployeeID').val("");
    $('#Name').val("");
    $('#Age').val("");
    $('#State').val("");
    $('#Country').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#Age').val().trim() == "") {
        $('#Age').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Age').css('border-color', 'lightgrey');
    }
    if ($('#State').val().trim() == "") {
        $('#State').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#State').css('border-color', 'lightgrey');
    }
    if ($('#Country').val().trim() == "") {
        $('#Country').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Country').css('border-color', 'lightgrey');
    }
    return isValid;
}