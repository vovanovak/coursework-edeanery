function validateDormitory(callback) {
    var dormitoryName = $("#Name").val();
    $.ajax({
        url: '/Dormitory/CheckDormitoryName?name=' + dormitoryName,
        type: "GET",
        success: function (data) {
            if (dormitoryName === '') {
                $('#NameValidationMsg').text("Dormitory name is empty");
                data.isValid = false;
            }
            
            if (data.isValid === false)
                $('#NameValidationMsg').text(data.message);
            
            if ($("#Address").val() === '') {
                data.isValid = false;
                $('#AddressValidationMsg').text("Address is required");
            } 
            
            callback(data);
        },
        error: function (response) {
            console.log(response);
        }
    });
}

function validateDormitoryRoom(callback) {
    var dormitoryRoomName = $("#DormitoryRoomName").val();
    $.ajax({
        url: '/DormitoryRoom/CheckDormitoryRoomName?name=' + dormitoryRoomName,
        type: "GET",
        success: function (data) {
            if (dormitoryRoomName === '') {
                $('#DormitoryRoomNameValidationMsg').text("Dormitory room name is empty");
                data.isValid = false;
            }
            
            if (data.isValid === false)
                $('#DormitoryRoomNameValidationMsg').text(data.message);

            if ($("#MaxCountInRoom").val() === '') {
                data.isValid = false;
                $('#MaxCountInRoomValidationMsg').text("Max Count In Room is required");
            }

            callback(data);
        },
        error: function (response) {
            console.log(response);
        }
    });
}

function validateGroup(callback) {
    var groupName = $("#GroupName").val();
    $.ajax({
        url: '/Group/CheckGroupName?name=' + groupName,
        type: "GET",
        success: function (data) {
            if (groupName === '') {
                data.isValid = false;
                $('#GroupNameValidationMsg').text("Dormitory room name is empty");
            }
            
            if (data.isValid === false)
                $('#GroupNameValidationMsg').text(data.message);

            callback(data);
        },
        error: function (response) {
            console.log(response);
        }
    });
}