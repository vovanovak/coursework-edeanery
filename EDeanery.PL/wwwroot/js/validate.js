function validateDormitory() {
    var dormitoryName = $("#Name").val();
    var result;
    
    $.ajax({
        url: '/Dormitory/CheckDormitoryName?name=' + dormitoryName,
        type: "GET",
        success: function (data) {
            if (data.isValid === false)
                $('#NameValidationMsg').text(data.message);
            
            result = data.isValid;
            
            console.log(data);
        },
        error: function (response) {
            console.log(response);
        }
    });
    
    return result;
}